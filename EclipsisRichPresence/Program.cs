using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordRPC;
using DiscordRPC.Logging;

namespace EclipsisRichPresence {
    class Program {
        static private DiscordRpcClient client;
        static private RichPresence lobbyPresence = new RichPresence() {
            Details = "In the lobby",
            //State = "asdfasdfasdfasdf",
            Assets = new Assets() {
                LargeImageKey = "iridium_crystal",
                LargeImageText = "Eclipsis"
                //SmallImageKey = "image_small"
            }
        };
        static string userInput;
        static bool initialized;

        public static void Initialize() {
            //this code was lazily CTRL+C'd and CTRL+V'd from the https://github.com/Lachee/discord-rpc-csharp README.md file because i'm lazy lmao

            /*
            Create a discord client
            NOTE: 	If you are using Unity3D, you must use the full constructor and define
                     the pipe connection.
            */
            client = new DiscordRpcClient("693125956960911391");

            //Set the logger
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

            //Subscribe to events
            client.OnReady += (sender, e) => {
                initialized = true;
                //Console.WriteLine("RPC Log: Received Ready from user {0}", e.User.Username);
            };

            client.OnPresenceUpdate += (sender, e) => {
                //Console.WriteLine("RPC Log: Received Update - {0}", e.Presence);
            };

            client.OnClose += (sender, e) => {
                //Console.WriteLine("RPC Log: Connection to Discord lost/terminated.");
            };

            //Connect to the RPC
            client.Initialize();
        }

        //These two do exactly what you think they do
        public static void WriteLineAsColor(string text, ConsoleColor color) {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void WriteAsColor(string text, ConsoleColor color) {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        static void OnProcessExit(object sender, EventArgs e) {
            //Gets rid of the RPC client on exit
            client.Dispose();
        }

        public static void SelectMatchType() {
            Console.Clear();
            Console.WriteLine("Select the type of match you're playing:");
            WriteAsColor("1 ", ConsoleColor.Cyan);
            Console.WriteLine("- Team Match, Rated");
            WriteAsColor("2 ", ConsoleColor.Cyan);
            Console.WriteLine("- Team Match, Unrated");
            WriteAsColor("3 ", ConsoleColor.Cyan);
            Console.WriteLine("- Solo Match, Rated");
            WriteAsColor("4 ", ConsoleColor.Cyan);
            Console.WriteLine("- Solo Match, Unrated");
            WriteAsColor("5 ", ConsoleColor.Cyan);
            Console.WriteLine("- Practice");
            Console.WriteLine();
            userInput = Console.ReadLine();
            switch (userInput) {
                case "1":
                    Console.Clear();
                    client.SetPresence(new RichPresence() {
                        Details = "In a match",
                        State = "Rated Team match",
                        Assets = new Assets() {
                            LargeImageKey = "iridium_crystal",
                            LargeImageText = "Eclipsis"
                            //SmallImageKey = "image_small"
                        },

                        Timestamps = new Timestamps() {
                            Start = DateTime.UtcNow,
                        }
                    });
                    Console.WriteLine("Presence set successfully!");

                    System.Threading.Thread.Sleep(3000);
                    Main();
                    break;
                case "2":
                    Console.Clear();
                    client.SetPresence(new RichPresence() {
                        Details = "In a match",
                        State = "Unrated Team match",
                        Assets = new Assets() {
                            LargeImageKey = "iridium_crystal",
                            LargeImageText = "Eclipsis"
                            //SmallImageKey = "image_small"
                        },

                        Timestamps = new Timestamps() {
                            Start = DateTime.UtcNow,
                        }
                    });
                    Console.WriteLine("Presence set successfully!");

                    System.Threading.Thread.Sleep(3000);
                    Main();
                    break;
                case "3":
                    Console.Clear();
                    client.SetPresence(new RichPresence() {
                        Details = "In a match",
                        State = "Rated Solo match",
                        Assets = new Assets() {
                            LargeImageKey = "iridium_crystal",
                            LargeImageText = "Eclipsis"
                            //SmallImageKey = "image_small"
                        },

                        Timestamps = new Timestamps() {
                            Start = DateTime.UtcNow,
                        }
                    });
                    Console.WriteLine("Presence set successfully!");

                    System.Threading.Thread.Sleep(3000);
                    Main();
                    break;
                case "4":
                    Console.Clear();
                    client.SetPresence(new RichPresence() {
                        Details = "In a match",
                        State = "Unrated Solo match",
                        Assets = new Assets() {
                            LargeImageKey = "iridium_crystal",
                            LargeImageText = "Eclipsis"
                            //SmallImageKey = "image_small"
                        },

                        Timestamps = new Timestamps() {
                            Start = DateTime.UtcNow,
                        }
                    });
                    Console.WriteLine("Presence set successfully!");

                    System.Threading.Thread.Sleep(3000);
                    Main();
                    break;
                case "5":
                    Console.Clear();
                    client.SetPresence(new RichPresence() {
                        Details = "In a match",
                        State = "Practice match",
                        Assets = new Assets() {
                            LargeImageKey = "iridium_crystal",
                            LargeImageText = "Eclipsis"
                            //SmallImageKey = "image_small"
                        },

                        Timestamps = new Timestamps() {
                            Start = DateTime.UtcNow,
                        }
                    });
                    Console.WriteLine("Presence set successfully!");

                    System.Threading.Thread.Sleep(3000);
                    Main();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Please select an option in the list.");

                    System.Threading.Thread.Sleep(3000);
                    SelectMatchType();
                    break;
            }
        }

        static void Main() {
            //Subscribe to the ProcessExist event
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            //If RPC isn't initialized, initialize it
            if (!initialized) {
                Initialize();
            }

            Console.Title = "Eclipsis Rich Presence";
            Console.Clear();

            //cancerous code but it works lmao
            WriteAsColor("Eclipsis ", ConsoleColor.Cyan);
            Console.WriteLine("Discord Rich Presence by Rubber Duck Shobe");
            Console.WriteLine();
            WriteAsColor("1 ", ConsoleColor.Cyan);
            Console.WriteLine("- Set lobby presence");
            WriteAsColor("2 ", ConsoleColor.Cyan);
            Console.WriteLine("- Set match presence");
            Console.WriteLine();
            userInput = Console.ReadLine();

            switch (userInput) {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Set lobby presence!");
                    client.SetPresence(lobbyPresence);

                    System.Threading.Thread.Sleep(3000);
                    Main();
                    break;

                case "2":
                    SelectMatchType();

                    System.Threading.Thread.Sleep(3000);
                    Main();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Please select an option in the list.");

                    System.Threading.Thread.Sleep(3000);
                    break;
            }
        }
    }
}
