//2016 Spyblood Games
//Do not distribute package without permission.

#pragma strict
var boostPower : float = 50; //how powerful it is
enum TypeOfBoost{Normal,Speed}; //this variable was added for fun. I just added them to simulate the "burnout x{number}" boost chain effect from the burnout series. if you set it to speed, you pretty much get unlimited boost. But you gotta earn it.
var BoostType : TypeOfBoost;
var flames : ParticleEmitter[]; //the actual ellipsoid particle emitter object 
 var flameColor : Color; //what color do you want the flame to be? (IMPORTANT: Remove all transparency to make the color visible!)
var boostBar : GameObject; //the actual image sprite that fills/depletes every time we boost
private var bar : UnityEngine.UI.Image; //fetch the Image component inside the boostBar
var speed : GameObject;
private var sd : UnityEngine.UI.Text;
private var boosting : boolean; //just a static boolean to see if we're boosting or not.
var consumptionRate : float = 0.5; //how fast the boost empties it's supply. and how fast it regenerates.
var audioObj : GameObject; //this object should be a seperate gameObject parented to the car.
private var wcs : WheelCollider[]; //since were using a simple Rigidbody and adding a force to it; it doesn't know if your car is on the ground or not. This variable is to prevent your car from flying like a rocket when you boost while in the air.
var mobileInput : boolean = false; //check this box in the editor to use this on your mobile device
var boostButtonGUI : GUITexture; //the actual button we're going to press to activate the boost (mobile only).

function Start () {
boostButtonGUI = GameObject.Find("BoostButton").GetComponent.<GUITexture>();//find the boost button object in the scene so we can use it.
sd = speed.GetComponent.<UnityEngine.UI.Text>();
wcs = gameObject.GetComponentsInChildren.<WheelCollider>();//what exactly are those wheel colliders?
audioObj.SetActive(false);//we dont need the sound to play when we're not using the nitro.
bar = boostBar.GetComponent.<UnityEngine.UI.Image>();
bar.fillAmount = 1;//set the bar's fill to full

for (var f : ParticleEmitter in flames)
{
f.emit = false;//dont want to emit flames when we're not boosting.
}
}

function Update () {
Boost();
BoostMobile();
}
function Boost()
{
if (mobileInput)
{
return; //dont turn on mobile input when we're using our computer!
}
boostButtonGUI.gameObject.SetActive(false);
sd.text = "" + Mathf.Round(GetComponent.<Rigidbody>().velocity.magnitude * 2.23693629);
bar.color = flameColor;//make sure that the fire's color is always the color you want.
if (Input.GetButton("Fire1")==true && bar.fillAmount > 0.025)
{
boosting = true;//hit ctrl and let it rip!
}
if (Input.GetButton("Fire1") == false || bar.fillAmount < .025)
{
audioObj.SetActive(false);//ok we're done. stop the sound and the particle effects.
boosting = false;
}
if (boosting)
{
bar.fillAmount -= consumptionRate * Time.deltaTime;// decrease the bar's amount by the consumption rate var
for (var wc : WheelCollider in wcs)
{
if (wc.isGrounded == true)
{
GetComponent.<Rigidbody>().AddForce(transform.forward * boostPower, ForceMode.Acceleration);//only add force when we're on the ground, ok?
}
if (BoostType == TypeOfBoost.Speed && wc.isGrounded)
{
GetComponent.<Rigidbody>().AddForce(transform.forward * boostPower, ForceMode.Acceleration);//this is where we can simulate that boost chain effect.
if (bar.fillAmount < 0.025 && boosting)
{
bar.fillAmount =1;
}
}
}
audioObj.SetActive(true);//NOW'S when we activate the sound.
for (var f : ParticleEmitter in flames)
{
f.emit = true;//emit the fire
var partAnim: ParticleAnimator = f.GetComponent.<ParticleAnimator>();
var colors : Color[] = partAnim.colorAnimation;
colors[0] = flameColor;
colors[1] = flameColor;
colors[3] = flameColor;
colors[4] = flameColor;
partAnim.colorAnimation = colors;
}
}
else if (!boosting && Input.GetButton("Fire1") == false)
{
audioObj.SetActive(false);
for (var wc : WheelCollider in wcs){
if (BoostType == TypeOfBoost.Normal || BoostType == TypeOfBoost.Speed){
{
if (wc.isGrounded == false){
bar.fillAmount += consumptionRate * Time.deltaTime;//refill the boost bar. But only if you're driving dangerously enough.
}
}
}
}
for (var f : ParticleEmitter in flames)
{
f.emit = false;//stop emitting.
}
}
}
//------------------------------------------------------------------------------------------------------------------------
function BoostMobile()
{
if (!mobileInput)
{
return;//dont turn on Standalone input when we're using our phone!
}
boostButtonGUI.gameObject.SetActive(true);
sd.text = "" + Mathf.Round(GetComponent.<Rigidbody>().velocity.magnitude * 2.23693629);
bar.color = flameColor;//make sure that the fire's color is always the color you want.
for (var touch : Touch in Input.touches)
{
if (touch.phase == TouchPhase.Stationary && boostButtonGUI.HitTest(touch.position) && bar.fillAmount > 0.025)
{
boosting = true;//hit the boost button and let it rip!
}
else if (touch.phase == TouchPhase.Ended && boostButtonGUI.HitTest || bar.fillAmount < .025)
{
audioObj.SetActive(false);//ok we're done. stop the sound and the particle effects.
boosting = false;
}
if (boosting)
{
bar.fillAmount -= consumptionRate * Time.deltaTime;// decrease the bar's amount by the consumption rate var
for (var wc : WheelCollider in wcs)
{
if (wc.isGrounded == true)
{
GetComponent.<Rigidbody>().AddForce(transform.forward * boostPower, ForceMode.Acceleration);//only add force when we're on the ground, ok?
}
if (BoostType == TypeOfBoost.Speed && wc.isGrounded)
{
GetComponent.<Rigidbody>().AddForce(transform.forward * boostPower, ForceMode.Acceleration);//this is where we can simulate that boost chain effect.
if (bar.fillAmount < 0.025 && boosting)
{
bar.fillAmount =1;
}
}
audioObj.SetActive(true);//NOW'S when we activate the sound.
for (var f : ParticleEmitter in flames)
{
f.emit = true;//emit the fire
var partAnim: ParticleAnimator = f.GetComponent.<ParticleAnimator>();
var colors : Color[] = partAnim.colorAnimation;
colors[0] = flameColor;
colors[1] = flameColor;
colors[3] = flameColor;
colors[4] = flameColor;
partAnim.colorAnimation = colors;
}
}
}
else if (!boosting && touch.phase == TouchPhase.Ended && boostButtonGUI.HitTest)
{
audioObj.SetActive(false);
for (var wc : WheelCollider in wcs){
if (wc.isGrounded == false){
if (BoostType == TypeOfBoost.Normal || BoostType == TypeOfBoost.Speed)
{
bar.fillAmount += consumptionRate * Time.deltaTime;//refill the boost bar. But only if you're driving dangerously enough.
}
}
}
for (var f : ParticleEmitter in flames)
{
f.emit = false;//stop emitting.
}
}
}
}