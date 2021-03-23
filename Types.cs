using ScratchSharp.Main;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
namespace ScratchSharp {
    namespace Types {

        /*
        I think it's worth mentioning that I don't truly understand Scratch's Compiler, nor do I have
        The full source code. All that I have is the project (.SB3) files, and the project json's by extension.
        I don't entirely know how it works, and do not modify the scratch source code at all, only use C# to
        translate into something I know the compiler can read. Anyway, that's it, legal stuff out of the way,
        heres my crappy code :)
        */


        public class Stage {
            public bool isStage {get; set;}
            public string name {get; set;}
            public Dictionary<string, List<object>> variables {get; set;}
            public Dictionary<string, List<object>> lists {get; set;}
            public Dictionary<string, string> broadcasts {get;}
            public Dictionary<string, Block> blocks {get; set;}
            public Dictionary<string, Comment> comments {get; set;}
            public int currentCostume {get; set;}
            public List<Costume> costumes {get; set;}
            public List<Sound> sounds {get; set;}
            public int volume {get; set;}
            public int layerOrder {get; set;}
            public int tempo {get; set;}
            public int videoTransparency {get; set;}
            public string videoState {get; set;}
            public object textToSpeechLanguage {get; set;}
            public Stage(string Name, bool IsStage = false){
                name = Name;
                blocks = new Dictionary<string, Block>();
                variables = new Dictionary<string, List<object>>();
                costumes = new List<Costume>();
                comments = new Dictionary<string, Comment>();
                lists = new Dictionary<string, List<object>>();
                currentCostume = 0;
                broadcasts = new Dictionary<string, string>();
                sounds = new List<Sound>();
                volume = 100;
                layerOrder = 0;
                tempo = 60;
                videoTransparency = 50;
                videoState = "on";
            }
            ///<summary>Registers sprite into Scratch program, any
            /// changes to sprite and you will need to re-register sprite
            ///</summary>
            public void RegisterStage(){
                Main.MainFunctions.json.targets.Add(this);
            }
            public void AddVariable(string name, object value){
                variables.Add(Text.GenerateID(), new List<object>() {name, value});
            }
            ///<summary>Removes the current instance
            /// of sprite from the targets list, removing it from
            /// scratch </summary>
            public void Destroy(){
                for(int i = 0; i < MainFunctions.json.targets.Count; i++){
                    if((MainFunctions.json.targets[i] as Stage).name == this.name){
                        MainFunctions.json.targets.RemoveAt(i);
                        break;
                    }
                }
            }
        }
        /// <summary>The root object used by all
        /// blocks, costumes, etc
        ///</summary>
        public class Sprite {
            public bool isStage {get; set;}
            public string name {get; set;}
            public Dictionary<string, List<object>> variables {get; set;}
            public Dictionary<string, List<object>> lists {get; set;}
            public Dictionary<string, string> broadcasts {get;}
            public Dictionary<string, object> blocks {get; set;}
            public Dictionary<string, Comment> comments {get; set;}
            public int currentCostume {get; set;}
            public List<Costume> costumes {get; set;}
            public List<Sound> sounds {get; set;}
            public int volume {get; set;}
            public int layerOrder {get; set;}
            public bool visible {get; set;}
            public int x {get; set;}
            public int y {get; set;}
            public int size {get; set;}
            public int direction {get; set;}
            public bool draggable {get; set;}
            public string rotationStyle {get; set;}
            public int tempo {get; set;}
            public int videoTransparency {get; set;}
            public string videoState {get; set;}
            public object textToSpeechLanguage {get; set;}
            public Sprite(string Name, int Direction = 90){
                direction = Direction;
                name = Name;
                isStage = false;
                blocks = new Dictionary<string, object>();
                variables = new Dictionary<string, List<object>>();
                costumes = new List<Costume>();
                comments = new Dictionary<string, Comment>();
                rotationStyle = "all around";
                x = 0;
                y = 0;
                size = 100;
                draggable = false;
                lists = new Dictionary<string, List<object>>();
                currentCostume = 0;
                broadcasts = new Dictionary<string, string>();
                sounds = new List<Sound>();
                volume = 100;
                layerOrder = 1;
                tempo = 60;
                videoTransparency = 50;
                videoState = "on";
                visible = true;
            }
            ///<summary>Registers sprite into Scratch program, any
            /// changes to sprite and you will need to re-register sprite
            ///</summary>
            public void RegisterSprite(){
                Main.MainFunctions.json.targets.Add(this);
            }
            public void AddVariable(string name, object value){
                variables.Add(Text.GenerateID(), new List<object>() {name, value});
            }
            ///<summary>Removes the current instance
            /// of sprite from the targets list, removing it from
            /// scratch </summary>
            public void Destroy(){
                for(int i = 0; i < MainFunctions.json.targets.Count; i++){
                    if((MainFunctions.json.targets[i] as Sprite).name == this.name){
                        MainFunctions.json.targets.RemoveAt(i);
                        break;
                    }
                }
            }
        }
        public class Costume {
            /*
            "assetId": "cd21514d0531fdffb22204e0ec5ed84a",
            "name": "backdrop1",
            "md5ext": "cd21514d0531fdffb22204e0ec5ed84a.svg",
            "dataFormat": "svg",
            "rotationCenterX": 240,
            "rotationCenterY": 180
            */
            public class SpriteCostume : Costume {
                public int bitmapResolution {get; set;}
                public SpriteCostume(string Name, int BitRes = 1, string DataFormat = "svg", int RotationCenterX = 48, int RotationCenterY = 50, string id = ""){
                    if(Name == ""){
                        name = Text.GenerateID();
                    }else name = Name;
                    bitmapResolution = BitRes;
                    dataFormat = DataFormat;
                    if(string.IsNullOrEmpty(id)){
                        for(int i = 0; i < 32; i++){
                            id += "abcdefghijklmnopqrstuvwxyz1234567890"[new System.Random().Next(35)];
                        }
                    }
                    assetId = id;
                    dataFormat = DataFormat;
                    md5ext = id + "." + dataFormat;
                    rotationCenterX = RotationCenterX;
                    rotationCenterY = RotationCenterY;
                }
            }
            public string assetId {get; set;}
            public string name {get; set;}
            public string md5ext {get; set;}
            public string dataFormat {get; set;}
            public int rotationCenterX {get; set;}
            public int rotationCenterY {get; set;}
            public Costume(string Name = "", string DataFormat = "svg", int RotationCenterX = 240, int RotationCenterY = 180, string id = ""){
                if(Name == ""){
                    name = Text.GenerateID();
                }else name = Name;
                
                dataFormat = DataFormat;
                if(string.IsNullOrEmpty(id)){
                    for(int i = 0; i < 32; i++){
                        id += "abcdefghijklmnopqrstuvwxyz1234567890"[new System.Random().Next(35)];
                    }
                }
                assetId = id;
                dataFormat = DataFormat;
                md5ext = id + "." + dataFormat;
                rotationCenterX = RotationCenterX;
                rotationCenterY = RotationCenterY;
            }
            public Costume(string Name){}
        }
        public class Sound {
            
            public string assetId {get;}
            public string name {get; set;}
            public string dataFormat {get;}
            public string format {get; set;}
            public int rate {get; set;}
            public int sampleCount {get; set;}
            public string md5ext {get;}
            public Sound(string Name, int SampleRate, int SampleCount, string DataFormat = "wav",  string id = ""){
                name = Name;
                sampleCount = SampleCount;
                rate = SampleRate;
                dataFormat = DataFormat;
                if(string.IsNullOrEmpty(id)){
                    for(int i = 0; i < 32; i++){
                        id += "abcdefghijklmnopqrstuvwxyz1234567890"[new System.Random().Next(35)];
                    }
                }
                assetId = id;
                dataFormat = DataFormat;
                md5ext = id + "." + dataFormat;
            }
        }
        public class Comment {
            public string blockID {get; private set;}
            private string ID {get; set;}
            public double x {get; set;}
            public double y {get; set;}
            public int width {get; set;}
            public int height {get; set;}
            public bool minimized {get; private set;}
            public string text {get; private set;}
            public Comment(string commenttext = "", int W = 200, int H = 200, double X = 0, double Y = 0, Block attachedTo = null){
                if(attachedTo != null) blockID = attachedTo.getID();
                ID = Text.GenerateID();
                x = X;
                y = Y;
                width = W;
                height = H;
                minimized = false;
                text = commenttext;
            }
            public string getID(){
                return this.ID;
            }
            public void minimize() {
                minimized = true;
            }
            public void maximize(){
                minimized = false;
            }
        }
        ///<summary>
        /// The most important class of all,
        /// holds all the Blocks you'd drag/drop in
        /// normal scratch
        ///</summary>
        public abstract class Block {
            // general block properties
            private string ID {get; set;}
            public string opcode {get; private set;}
            public string next {get; set;}
            public string parent {get; set;}
            public Dictionary<string, List<object>> inputs {get; private set;}
            public Dictionary<string, List<object>> fields {get; private set;}
            public bool shadow {get; private set;}
            public bool topLevel {get; private set;}
            
            
            public class GoBackLayers : Block {
                public GoBackLayers(int layers){
                    opcode = "looks_goforwardbackwardlayers";
                    var ls = new List<object>();
                    inputs = new Dictionary<string, List<object>>();
                    fields = new Dictionary<string, List<object>>();
                    ls.Add(1);
                    ls.Add(new List<object>() {7, layers.ToString()});
                    inputs.Add("NUM", ls);

                    ls = new List<object>();
                    ls.Add("backward");
                    ls.Add(null);
                    fields.Add("FORWARD_BACKWARD", ls);
                    ID = Text.GenerateID();
                }
            }
            public class WhenBgChangeTo : Block {
                public WhenBgChangeTo(Costume bg){
                    string name = bg.name;
                    opcode = "event_whenbackdropswitchesto";
                    shadow = false;
                    topLevel = true;
                    var ls = new List<object>();
                    ls.Add(name);
                    ls.Add(null);
                    inputs = new Dictionary<string, List<object>>();
                    fields = new Dictionary<string, List<object>>();
                    fields.Add("BACKDROP", ls);
                    ID = Text.GenerateID();
                }
            }
            public class WhenSpriteClicked : Block {
                public WhenSpriteClicked(){
                    opcode = "event_whenthisspriteclicked";
                    inputs = new Dictionary<string, List<object>>();
                    fields = new Dictionary<string, List<object>>();
                    shadow = false;
                    topLevel = true;
                    ID = Text.GenerateID();
                }
            }
            public class WhenKeyPressed : Block {
                public enum Keys {
                    space, any, left_arrow, right_arrow, up_arrow,
                    down_arrow, a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r,
                    s, t, u, v, w, x, y, z, k1, k2, k3, k4, k5, k6, k7, k8, k9, k0,  
                };
                public WhenKeyPressed(Keys key){
                    opcode = "event_whenkeypressed";
                    inputs = new Dictionary<string, List<object>>();
                    fields = new Dictionary<string, List<object>>();
                    var ls = new List<object>();
                    shadow = false;
                    topLevel = true;
                    string trueKeyName = string.Empty;
                    switch(key){
                        case Keys.left_arrow:
                        case Keys.right_arrow:
                        case Keys.up_arrow:
                        case Keys.down_arrow:
                            trueKeyName = nameof(key).Replace("_", " ");
                            break;
                        case Keys.k1:
                        case Keys.k2:
                        case Keys.k3:
                        case Keys.k4:
                        case Keys.k5:
                        case Keys.k6:
                        case Keys.k7:
                        case Keys.k8:
                        case Keys.k9:
                        case Keys.k0:
                            trueKeyName = nameof(key).Replace("k", "");
                            break;
                        default:
                            trueKeyName = nameof(key);
                            break;
                    }
                    ls.Add(trueKeyName);
                    ls.Add(null);
                    fields.Add("KEY_OPTION", ls);
                    ID = Text.GenerateID();
                }
            }
            public class GoForwardLayers : Block {
                public GoForwardLayers(int layers){
                    opcode = "looks_goforwardbackwardlayers";
                    var ls = new List<object>();
                    inputs = new Dictionary<string, List<object>>();
                    fields = new Dictionary<string, List<object>>();
                    ls.Add(1);
                    ls.Add(new List<object>() {7, layers.ToString()});
                    inputs.Add("NUM", ls);

                    ls = new List<object>();
                    ls.Add("forward");
                    ls.Add(null);
                    fields.Add("FORWARD_BACKWARD", ls);

                    shadow = false;
                    topLevel = false;
                    ID = Text.GenerateID();
                }
            }
            public class NextBackdrop : Block {
                public NextBackdrop(){
                    ID = Text.GenerateID();
                    inputs = new Dictionary<string, List<object>>();
                    fields = new Dictionary<string, List<object>>();
                    opcode = "looks_nextbackdrop";
                    shadow = false;
                    topLevel = false;
                }
            }
            public class GoToBackLayer : Block {
                public GoToBackLayer(){
                    opcode = "looks_gotofrontback";
                    inputs = new Dictionary<string, List<object>>();
                    fields = new Dictionary<string, List<object>>();
                    shadow = false;
                    topLevel = true;
                    var ls = new List<object>();
                    ls.Add("back");
                    ls.Add(null);
                    fields.Add("FRONT_BACK", ls);
                    ID = Text.GenerateID();
                }
            }
            public class GoToFrontLayer : Block {
                public GoToFrontLayer(){
                    opcode = "looks_gotofrontback";
                    inputs = new Dictionary<string, List<object>>();
                    fields = new Dictionary<string, List<object>>();
                    shadow = false;
                    topLevel = true;
                    var ls = new List<object>();
                    ls.Add("front");
                    ls.Add(null);
                    fields.Add("FRONT_BACK", ls);
                    ID = Text.GenerateID();
                }
            }
            public class Hide : Block {
                public Hide(){
                    opcode = "looks_hide";
                    inputs = new Dictionary<string, List<object>>();
                    fields = new Dictionary<string, List<object>>();
                    shadow = false;
                    topLevel = false;
                    ID = Text.GenerateID();
                }
            }
            public class Show : Block {
                public Show(){
                    opcode = "looks_show";
                    inputs = new Dictionary<string, List<object>>();
                    fields = new Dictionary<string, List<object>>();
                    shadow = false;
                    topLevel = false;
                    ID = Text.GenerateID();
                }
            }
            public class ClearGraphicsEffects : Block {
                public ClearGraphicsEffects(){
                    opcode = "looks_cleargraphiceffects";
                    inputs = new Dictionary<string, List<object>>();
                    fields = new Dictionary<string, List<object>>();
                    shadow = false;
                    topLevel = false;
                    ID = Text.GenerateID();
                }
            }
            public class SetEffectTo : Block {
                public enum Effects {
                    COLOR,
                    FISHEYE,
                    WHIRL,
                    PIXELATE,
                    MOSAIC,
                    BRIGHTNESS,
                    GHOST
                };
                public SetEffectTo(int changeto, Effects effect){
                    opcode = "looks_seteffectto";
                    var ls = new List<object>();
                    ls.Add(1);
                    ls.Add(new List<object>() {4, changeto.ToString()});

                    inputs = new Dictionary<string, List<object>>();
                    fields = new Dictionary<string, List<object>>();

                    inputs.Add("VALUE", ls);

                    ls = new List<object>();
                    ls.AddRange(new List<object>() {nameof(effect), null});
                    fields.Add("EFFECT", ls);
                    shadow = false;
                    topLevel = false;
                    ID = Text.GenerateID();
                }
            }
            public class ChangeEffectBy : Block {
                public enum Effects {
                    COLOR,
                    FISHEYE,
                    WHIRL,
                    PIXELATE,
                    MOSAIC,
                    BRIGHTNESS,
                    GHOST
                };
                public ChangeEffectBy(int changeby, Effects effect){
                    string effectname = nameof(effect);
                    fields = new Dictionary<string, List<object>>(); // has effect
                    inputs = new Dictionary<string, List<object>>(); // has changeby value
                    var flis = new List<object>();
                    flis.Add(effectname);
                    flis.Add(null);
                    fields.Add("EFFECT", flis);
                    var inlis = new List<object>();
                    inlis.Add(1);
                    inlis.Add(new List<object>() {4, changeby.ToString()});
                    inputs.Add("CHANGE", inlis);
                    shadow = false;
                    topLevel = false;
                    ID = Text.GenerateID();
                }
            }
            public class ChangeSizeTo : Block {
                public ChangeSizeTo(int size){
                    opcode = "looks_setsizeto";
                    inputs = new Dictionary<string, List<object>>();
                    fields = new Dictionary<string, List<object>>();
                    var ls = new List<object>();
                    ls.Add(1);
                    ls.Add(new List<object>() {4, size.ToString()});
                    inputs.Add("SIZE", ls);
                    shadow = false;
                    topLevel = false;
                    ID = Text.GenerateID();
                }
            }
            public class ChangeSizeBy : Block {
                public ChangeSizeBy(int size){
                    opcode = "looks_changesizeby";
                    inputs = new Dictionary<string, List<object>>();
                    fields = new Dictionary<string, List<object>>();
                    var ls = new List<object>();
                    ls.Add(1);
                    ls.Add(new List<object>() {4, size.ToString()});
                    inputs.Add("CHANGE", ls);
                    shadow = false;
                    topLevel = false;
                    ID = Text.GenerateID();
                }
            }
            public class ChangeBackdrop : Block {
                BackDrop backDrop {get; set;}
                public ChangeBackdrop(Costume new_backdrop){
                    ID = Text.GenerateID();
                    backDrop = new BackDrop(new_backdrop, this.ID);
                    opcode = "looks_switchbackdropto";
                    inputs = new Dictionary<string, List<object>>();
                    var ls = new List<object>();
                    ls.Add(1);
                    ls.Add(backDrop.getID());
                    inputs.Add("BACKDROP", ls);
                    fields = new Dictionary<string, List<object>>();
                    shadow = false;
                    ID = Text.GenerateID();
                    topLevel = false;
                }
            }
            public class NextCostume : Block {
                public NextCostume(){
                    ID = Text.GenerateID();
                    inputs = new Dictionary<string, List<object>>();
                    fields = new Dictionary<string, List<object>>();
                    opcode = "looks_nextcostume";
                    topLevel = false;
                    shadow = false;
                }
            }
            private class BackDrop : Block {
                public BackDrop(Costume new_backdrop, string parentID){
                    ID = Text.GenerateID();
                    opcode = "looks_backdrops";
                    List<object> ls = new List<object>();
                    ls.Add(new List<object> {new_backdrop.name, null});
                    inputs = new Dictionary<string, List<object>>();
                    fields = new Dictionary<string, List<object>>();
                    fields.Add("BACKDROP", ls);
                    shadow = false;
                    topLevel = false;
                    parent = parentID;
                }
            }

            public class Say : Block {
                // say for secs
                public Say(int secs, string message){
                    List<object> ls = new List<object>();
                    ls.Add(1);
                    ls.Add(new List<object> {10, message.ToString()});
                    inputs = new Dictionary<string, List<object>>();
                    inputs.Add("MESSAGE", ls);
                    ls = new List<object>();
                    ls.Add(1);
                    ls.Add(new List<object>() {4, secs.ToString()});
                    inputs.Add("SECS", ls);
                    opcode = "looks_sayforsecs";
                    ID = Text.GenerateID();
                    fields = new Dictionary<string, List<object>>(); 
                    topLevel = false;
                    shadow = false;
                }
                // just say
                public Say(string message){
                    var ls = new List<object>();
                    inputs = new Dictionary<string, List<object>>();
                    ls.Add(1);
                    ls.Add(new List<object>() {10, message.ToString()});
                    inputs.Add("MESSAGE", ls);
                    opcode = "looks_say";
                    ID = Text.GenerateID();
                    fields = new Dictionary<string, List<object>>(); 
                    topLevel = false;
                    shadow = false;
                }
            }
            public class Think : Block {
                public Think(int secs, string message){
                    List<object> ls = new List<object>();
                    ls.Add(1);
                    ls.Add(new List<object> {10, message.ToString()});
                    inputs = new Dictionary<string, List<object>>();
                    inputs.Add("MESSAGE", ls);
                    ls = new List<object>();
                    ls.Add(1);
                    ls.Add(new List<object>() {4, secs.ToString()});
                    inputs.Add("SECS", ls);
                    opcode = "looks_thinkforsecs";
                    ID = Text.GenerateID();
                    fields = new Dictionary<string, List<object>>(); 
                    topLevel = false;
                    shadow = false;
                }
                public Think(string message){
                    var ls = new List<object>();
                    ls.Add(1);
                    ls.Add(new List<object>() {10, message.ToString()});
                    inputs.Add("MESSAGE", ls);
                    opcode = "looks_think";
                    ID = Text.GenerateID();
                    fields = new Dictionary<string, List<object>>(); 
                    topLevel = false;
                    shadow = false;
                }
            }
            public class MoveSteps : Block {
                public MoveSteps(int steps){
                    List<object> ls = new List<object>();
                    ls.Add(1);
                    ls.Add(new List<object> {4, steps.ToString()});
                    inputs = new Dictionary<string, List<object>>();
                    inputs.Add("STEPS", ls);
                    opcode = "motion_movesteps";
                    ID = Text.GenerateID();
                    fields = new Dictionary<string, List<object>>(); // this too :)
                    topLevel = false;
                    shadow = false;
                }
            }
            public class TurnRight : Block {

                public TurnRight(int Degrees){
                    List<object> ls = new List<object>();
                    ls.Add(1);
                    ls.Add(new List<object> {4, Degrees.ToString()});
                    inputs = new Dictionary<string, List<object>>();
                    inputs.Add("DEGREES", ls);
                    opcode = "motion_turnright";
                    ID = Text.GenerateID();
                    fields = new Dictionary<string, List<object>>(); // this too :)
                    topLevel = false;
                    shadow = false;
                }
            }
            public class IfOnEdgeBounce : Block {
                public IfOnEdgeBounce(){
                    ID = Text.GenerateID();
                    opcode = "motion_ifonedgebounce";
                    inputs = new Dictionary<string, List<object>>();
                    fields = new Dictionary<string, List<object>>();
                    shadow = false;
                    topLevel = false;
                }
            }
            public class TurnLeft : Block {

                public TurnLeft(int Degrees){
                    List<object> ls = new List<object>();
                    ls.Add(1);
                    ls.Add(new List<object> {4, Degrees.ToString()});
                    inputs = new Dictionary<string, List<object>>();
                    inputs.Add("DEGREES", ls);
                    opcode = "motion_turnleft";
                    ID = Text.GenerateID();
                    fields = new Dictionary<string, List<object>>(); // this too :)
                    topLevel = false;
                    shadow = false;
                }
            }
            
            public class Xpos : Block {
                public Xpos() {
                    opcode = "motion_xposition";
                    inputs = new Dictionary<string, List<object>>();
                    fields = new Dictionary<string, List<object>>();
                    shadow = false;
                    topLevel = false;
                    ID = Text.GenerateID();
                }
            }
            public class Ypos : Block {
                public Ypos() {
                    opcode = "motion_yposition";
                    inputs = new Dictionary<string, List<object>>();
                    fields = new Dictionary<string, List<object>>();
                    shadow = false;
                    topLevel = false;
                    ID = Text.GenerateID();
                }
            }
            public class Direction : Block {
                public Direction(){
                    opcode = "motion_direction";
                    inputs = new Dictionary<string, List<object>>();
                    fields = new Dictionary<string, List<object>>();
                    shadow = false;
                    topLevel = false;
                    ID = Text.GenerateID();
                }
            }
            public class WaitForSeconds : Block {

                public WaitForSeconds(int seconds){
                    opcode = "control_wait";
                    List<object> ls = new List<object>();
                    ls.Add(1);
                    ls.Add(new List<object> {5, seconds.ToString()});
                    inputs = new Dictionary<string, List<object>>();
                    inputs.Add("DURATION", ls);
                    ID = Text.GenerateID();
                    fields = new Dictionary<string, List<object>>();
                    topLevel = false;
                    shadow = false;
                }
            }
            public class PointInDirection : Block {
                public PointInDirection(int direction) {
                    opcode = "motion_pointindirection";
                    List<object> ls = new List<object>();
                    ls.Add(1);
                    ls.Add(new List<object> {8, direction.ToString()});
                    inputs = new Dictionary<string, List<object>>();
                    inputs.Add("DIRECTION", ls);
                    ID = Text.GenerateID();
                    fields = new Dictionary<string, List<object>>();
                    topLevel = false;
                    shadow = false;
                }
            }
            public class GlideToXY : Block {
                public GlideToXY(int secs, int x, int y){
                    inputs = new Dictionary<string, List<object>>();
                    List<object> ls = new List<object>();
                    ls.Add(1);
                    ls.Add(new List<object>() {4, secs.ToString()});
                    inputs.Add("SECS", ls);
                    ls = new List<object>();
                    ls.Add(1);
                    ls.Add(new List<object> {4, x.ToString()});
                    
                    inputs.Add("X", ls);
                    ls = new List<object>();
                    ls.Add(1);
                    ls.Add(new List<object>() {4, y.ToString()});
                    inputs.Add("Y", ls);
                    opcode = "motion_glidesecstoxy";
                    ID = Text.GenerateID();
                    fields = new Dictionary<string, List<object>>(); // this too :)
                    topLevel = false;
                    shadow = false;
                }
            }
            public class GoToXY : Block {
                public GoToXY(int x, int y){
                    List<object> ls = new List<object>();
                    ls.Add(1);
                    ls.Add(new List<object> {4, x.ToString()});
                    inputs = new Dictionary<string, List<object>>();
                    inputs.Add("X", ls);
                    ls = new List<object>();
                    ls.Add(1);
                    ls.Add(new List<object>() {4, y.ToString()});
                    inputs.Add("Y", ls);
                    opcode = "motion_gotoxy";
                    ID = Text.GenerateID();
                    fields = new Dictionary<string, List<object>>(); // this too :)
                    topLevel = false;
                    shadow = false;
                }
            }
            public class ChangeXBy : Block {
                public ChangeXBy(int xDistance) {
                    List<object> ls = new List<object>();
                    ls.Add(1);
                    ls.Add(new List<object> {4, xDistance.ToString()});
                    inputs = new Dictionary<string, List<object>>();
                    inputs.Add("DX", ls);
                    opcode = "motion_changexby";
                    ID = Text.GenerateID();
                    fields = new Dictionary<string, List<object>>(); // this too :)
                    topLevel = false;
                    shadow = false;
                }
            }
            public class ChangeYBy : Block {
                public ChangeYBy(int yDistance) {
                    List<object> ls = new List<object>();
                    ls.Add(1);
                    ls.Add(new List<object> {4, yDistance.ToString()});
                    inputs = new Dictionary<string, List<object>>();
                    inputs.Add("DY", ls);
                    opcode = "motion_changeyby";
                    ID = Text.GenerateID();
                    fields = new Dictionary<string, List<object>>(); // this too :)
                    topLevel = false;
                    shadow = false;
                }
            }
            public class SetX : Block {
                public SetX(int xpos){
                    opcode = "motion_setx";
                    List<object> ls = new List<object>();
                    ls.Add(1);
                    ls.Add(new List<object> {4, xpos.ToString()});
                    inputs = new Dictionary<string, List<object>>();
                    inputs.Add("X", ls);
                    ID = Text.GenerateID();
                    fields = new Dictionary<string, List<object>>(); // this too :)
                    topLevel = false;
                    shadow = false;
                }
            }
            public class SetY : Block {
                public SetY(int ypos){
                    opcode = "motion_sety";
                    List<object> ls = new List<object>();
                    ls.Add(1);
                    ls.Add(new List<object> {4, ypos.ToString()});
                    inputs = new Dictionary<string, List<object>>();
                    inputs.Add("Y", ls);
                    ID = Text.GenerateID();
                    fields = new Dictionary<string, List<object>>(); // this too :)
                    topLevel = false;
                    shadow = false;
                }
            }
            public class OnFlagClicked : Block {
                public OnFlagClicked(){
                    ID = Text.GenerateID();
                    opcode = "event_whenflagclicked";
                    parent = null;
                    inputs = new Dictionary<string, List<object>>(); // this must remain "null"
                    fields = new Dictionary<string, List<object>>(); // this too :)
                    topLevel = true;
                    shadow = false;
                }
            }
            public string getID(){
                return ID;
            }
        }
        
        ///<summary>
        /// Allows you to specify a chain of blocks to add
        /// to a sprite, in which they will automatically set
        /// their respective Next and Parent variables
        ///</summary>
        public class BlockChain {
            public Block[] Chain {get; set;}
            public BlockChain(Block[] bodyls){
                for(int i = 0; i < bodyls.Length; i++){
                    if(i == 1){
                        bodyls[i].parent = bodyls[0].getID();
                       try{ bodyls[i].next = bodyls[i + 1].getID(); }
                       catch {bodyls[i].next = null;}
                    } else if(i == bodyls.Length - 1){
                        bodyls[i].next = null;
                        try{bodyls[i].parent = bodyls[i - 1].getID();}
                        catch {bodyls[i].parent = null;}
                    } else {
                        try{bodyls[i].parent = bodyls[i - 1].getID();}
                        catch {bodyls[i].parent = null;}
                       try{ bodyls[i].next = bodyls[i + 1].getID(); }
                       catch {bodyls[i].next = null;}
                    }
                }
                Chain = bodyls;
            }
            public void AddToSprite(Sprite s){
                foreach(var b in Chain){
                    s.blocks.Add((b).getID(), (b));
                }
            }
        }
        public class Variable {
            public int Value {get; set;}
            public string ID {get;}
            public string Name {get;}
            /// <summary>The sprite this variable is attached to</summary>
            public Sprite AttachedSprite {get;}

            public Variable(string name, int value, Sprite sprite){
                AttachedSprite = sprite;
                Value = value;
                Name = name;
                ID = Text.GenerateID();
            }
        }
    }
}