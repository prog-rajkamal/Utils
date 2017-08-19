using System.IO;
using System.Text;
using System;
using CommandLineParser.Arguments;
using CommandLineParser.Exceptions;
using System.Text.RegularExpressions;


namespace Cryptography
{

    class CryptProgram
    {
        static void Main(string[] args)
        {

            CommandLineParser.CommandLineParser parser = new CommandLineParser.CommandLineParser();

            if(args.Length == 0)
            {
                showHelp();
                return;
            }

            var p = new CommandLineOptions();

            Regex r = new Regex("(.*)=(.*)");
            Match m = r.Match(args[0]);

            parser.AcceptEqualSignSyntaxForValueArguments = true;
            parser.PreserveValueQuotesForEqualsSignSyntax = true;
            parser.AllowShortSwitchGrouping = false;
            parser.AcceptHyphen = true;
            parser.ExtractArgumentAttributes(p);

            try {
                parser.ParseCommandLine(args);
            }
            catch (CommandLineException e) {
                Console.WriteLine(e.Message);
                parser.ShowUsage();
            }
            
            parser.ShowParsedArguments();
            var encrypter = new Encrypter();
            string text, pass, code;
            text = p.text; 
            pass = p.key;
            if (p.decrypt == false) {
                code = encrypter.Encrypt(text, pass);
                Console.Write("Encrypted: ");
                Console.Write(code);

            }
            else {
                try {
                    code = encrypter.Decrypt(text, pass);
                    Console.Write(code);
                    Console.Write(code);

                }
                catch(FormatException fex){
                    Console.WriteLine("Format Exception: text is not in correct format. \r\nException message: "+fex.Message);
                }
                Console.Write("Decrypted: ");
            }
            Console.WriteLine("Program finished");


        }

        private static void showHelp()
        {
            Console.WriteLine(
@"
    ------========= CryptoGraphy Program ======-----
    Usage: 
cryptography [-e|--encrypt] [-d|--decrypt] --text={Text} --key={Key}

If you don't specify either encryption or decryption flag, then error will be raised.

");
        }
    }
    class CommandLineOptions
    {
        [ValueArgument(typeof(string), "text", Description = "Plain/Cipher Text")]
        public string text { get; set; }

        [ValueArgument(typeof(string), "key", Description = "Encryption Key")]
        public string key { get; set; }
      
        /* SwitchArguments - for on/off boolean logic */
        [SwitchArgument('d', "decrypt", false, Description = "Set this to decrypt")]
        public bool decrypt { get; set; }
        /* SwitchArguments - for on/off boolean logic */
        
        [SwitchArgument('e', "encrypt", false, Description = "Set this to decrypt")]
        public bool encrypt { get; set; }

                     

    }

}
