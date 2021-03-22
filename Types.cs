using ScratchSharp.Main;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
namespace ScratchSharp {
    namespace Types {
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