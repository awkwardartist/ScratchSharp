using System;
using System.Threading;
using ScratchSharp.Types;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
namespace ScratchSharp
{
    namespace Main {
        public class Text {
            public static string GenerateID(){
                string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!^&()[]abcdefghijklmnopqrstuvwxyz";
                string ret = string.Empty;
                for(int i = 0; i < 20; i++){
                    ret += allowedChars[new Random().Next(allowedChars.Length - 1)];
                }
                return ret;
            }
        }
        public abstract class MainFunctions {
            public static JSON json = new JSON();
        }
        public class JSON {
            public List<object> targets {get; set;}
            /// <summary> The pop up boxes which display data to the screen </summary>
            public List<object> monitors {get; set;}
            public List<object> extensions {get; set;}
            /// <summary> meta data for the compiler,
            /// can be safely ignored
            /// </summary>
            public MetaData meta {get; set;}
            public JSON(){
                meta = new MetaData();
                targets = new List<object>();
                monitors = new List<object>();
                extensions = new List<object>();
            }
            public void VerifyLists(){
                for(int i = 0; i < targets.Count; i++){
                    if(targets[i] is not Sprite && targets[i] is not Stage){
                        targets.RemoveAt(i);
                        i = 0;
                    }
                }
            }
            ///<summary>
            /// Path to zip must be a full path, including the .sb3 extension, and
            /// the asset folder can't have nested directories
            ///</summary>
            public static void WriteToZIP(string path_to_zip, string path_to_assets_folder){
                string jsonStr = JsonSerializer.Serialize(MainFunctions.json);
                Directory.CreateDirectory(path_to_zip.Remove(path_to_zip.LastIndexOf(".")));
                foreach(var fl in Directory.GetFiles(path_to_assets_folder)){
                    string fileName = fl.Substring(fl.LastIndexOf("\\"));
                    File.Copy(fl, path_to_zip.Remove(path_to_zip.LastIndexOf(".")) + fileName);
                }
                File.WriteAllText(path_to_zip.Remove(path_to_zip.LastIndexOf(".")) + "\\project.json", jsonStr);
                // create, if it already exists delete then replace
                try {ZipFile.CreateFromDirectory(path_to_zip.Remove(path_to_zip.LastIndexOf(".")), path_to_zip);} catch {
                    File.Delete(path_to_zip);
                    ZipFile.CreateFromDirectory(path_to_zip.Remove(path_to_zip.LastIndexOf(".")), path_to_zip);
                }
                // remove the dir safely
                new Thread(() => {
                    int attempts = 0;
                    while(true){
                        if(!Directory.Exists(path_to_zip.Remove(path_to_zip.LastIndexOf("."))))
                            break;
                        else {
                            if(attempts > 100) break;
                            try{
                                foreach(var fl in Directory.GetFiles(path_to_zip.Remove(path_to_zip.LastIndexOf(".")))){
                                    // clear the dir, they must be empty to be deleted
                                    File.Delete(fl);
                                }
                                // delete it, will break if it was successful
                                Directory.Delete(path_to_zip.Remove(path_to_zip.LastIndexOf(".")));
                            } catch {}
                        }
                        attempts++;
                    }
                }).Start();
            }
            public class MetaData{
                public string semver {get; set;}
                public string vm {get; set;}
                public string agent {get; set;}
                public MetaData(){
                    // hard coded values, do not change
                    semver = "3.0.0";
                    vm = "0.2.0-prerelease.20210224111250";
                    agent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36" + 
                    " (KHTML, like Gecko) Scratch/3.20.1 Chrome/80.0.3987.165 Electron/8.2.5 Safari/537.36";
                }
            }   
        }
    }
    
}
