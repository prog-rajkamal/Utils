using CommandLineParser.Arguments;
using CommandLineParser.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clireader
{
    class CliReaderProgram 
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
      

        /* args contains command line arguments */
        static void Main(string[] args)
        {
            /* create the CommandLineParser instance */
            CommandLineParser.CommandLineParser parser = new CommandLineParser.CommandLineParser();

            logger.Info("Parsing started!");  
            var p = new CommandLineOptions();

            parser.AcceptEqualSignSyntaxForValueArguments = true;
            parser.ExtractArgumentAttributes(p);

            try {
                parser.ParseCommandLine(args);
            }
            catch (CommandLineException e) {
                Console.WriteLine(e.Message);
                parser.ShowUsage();
            }

            DateTime dt = DateTime.Parse(p.startDate, CultureInfo.InvariantCulture);
            

            logger.Info("Done");
        }

        
    }


    class CommandLineOptions
    {

        [EnumeratedValueArgument(typeof(string), "gen", AllowedValues = "smart;bulk;manual", DefaultValue="bulk")]
        public string generation;

        /* SwitchArguments - for on/off boolean logic */
        [SwitchArgument('h', "semimonthly", true, Description = "Set if Semi monthly reports should be generated")]
        public bool show;

        [SwitchArgument('m', "monthly", false, Description = "Set if Monthly reports should be generated")]
        public bool hide
        {
            get;
            set;
        }


        [ValueArgument(typeof(string), 's', "startdate", Description = "Start Date:")]
        public string startDate;

        [ValueArgument(typeof(string), 'e', "enddate", Description = "Start Date:")]
        public string endDate;
           
    

        /* FileArgument has standard .NET FileInfo class as a value, it can be used when 
         * the progrem processes input files */
        [FileArgument("config", Description = "Config file", FileMustExist=true)]
        public FileInfo inputFile;

       
    }
   
    /* arguments are defined using attributes, parsed values will be mapped to fields or properties*/
class ParsingTarget
{
    /* SwitchArguments - for on/off boolean logic */
    [SwitchArgument('s', "show", true, Description = "Set whether show or not")]
    public bool show;

    private bool hide;
    [SwitchArgument('h', "hide", false, Description = "Set whether hide or not")]
    public bool Hide
    {
        get { return hide; }
        set { hide = value; }
    }

    /* ValueArguments - used like this: --level easy --version 1.3 */
    [ValueArgument(typeof(decimal), "version", Description = "Set desired version")]
    public decimal version;

    [ValueArgument(typeof(string), 'l', "level", Description = "Set the level")]
    public string level;

    /* BoundedValueArgument checks the value belongs to an interval => -o 4 would throw an error */
    [BoundedValueArgument(typeof(int), 'o', "optimization",
        MinValue = 0, MaxValue = 3, Description = "Level of optimization")]
    public int optimization;

    /* EnumeratedValueArgument allows only some values => --color yellow would throw an error */
    [EnumeratedValueArgument(typeof(string), 'c', "color", AllowedValues = "red;green;blue")]
    public string color;

    /* FileArgument has standard .NET FileInfo class as a value, it can be used when 
     * the progrem processes input files */
    [FileArgument('i', "input", Description = "Input file", FileMustExist = true)]
    public FileInfo inputFile;

    /* FileArgument can also be used for output files, in this case you will want to 
     * set FileMustExist flag to false */
    [FileArgument('x', "output", Description = "Output file", FileMustExist = false)]
    public FileInfo outputFile;

    /* DirectoryArgument is simalar to FileArgument*/
    [DirectoryArgument('d', "directory", Description = "Input directory", DirectoryMustExist = false)]
    public DirectoryInfo InputDirectory;
}
   


    ///// <summary>
    ///// Classes for CommandLine library
    ///// </summary>
    //class SmartGenSubOptions 
    //{
    //    [Option('c', "config", HelpText = " COnfig file containing other options and DB creds")]
    //    public string config { get; set; }
  
    //    [Option('a', "all", HelpText = "All reports will be done")]
    //    public bool All { get; set; }
    //    // Remainder omitted

    //}

    //class DumbGenSubOptions : SmartGenSubOptions
    //{
    //    [Option("start-date", HelpText = "Start Date for reports")]
    //    public DateTime startDate { get; set; }

    //    [Option("end-date", HelpText = "End date for reports")]        
    //    public DateTime endDate { get; set; }
    //}

    //class BulkGenSubOptions : SmartGenSubOptions
    //{
    //    // Remainder omitted
    //    [Option("semimonthly", HelpText = "End date for reports")]         
    //    public bool SemiMonthly { get; set; }

    //    [Option("mothly", HelpText = "End date for reports")]                    
    //    public bool Monthly { get; set; }
    //}

    //class Options
    //{
    //    public Options()
    //    {
    //        // Since we create this instance the parser will not overwrite it
    //        SmartGenVerb = new SmartGenSubOptions { All = true };
    //    }

    //    [VerbOption("commit", HelpText = "Record changes to the repository.")]
    //    public SmartGenSubOptions SmartGenVerb{ get; set; }

    //    [VerbOption("push", HelpText = "Update remote refs along with associated objects.")]
    //    public BulkGenSubOptions BulkGenVerb { get; set; }

    //    [VerbOption("tag", HelpText = "Update remote refs along with associated objects.")]
    //    public DumbGenSubOptions Verb { get; set; }
    //}


    //class TOptions
    //{
    //    //[Option('r', "read", Required = true,
    //    //  HelpText = "Input files to be processed.")]
    //    //public IEnumerable<string> InputFiles { get; set; }

    //    [Option("report", Required = true,
    //      HelpText = "Input files to be processed.")]
    //    public string inp1 { get; set; }

    //    [Option("config", Required = true,
    //     HelpText = "Input files to be processed.")]
    //    public string config { get; set; }

    //    // Omitting long name, default --verbose
    //    [Option(
    //      HelpText = "Prints all messages to standard output.")]
    //    public bool Verbose { get; set; }

    //    [Option(DefaultValue = "??????",
    //      HelpText = "Content language.")]
    //    public string Language { get; set; }

    //    [Option(DefaultValue= null, MetaValue= "offset",
    //      HelpText = "File offset.")]
    //    public long? Offset { get; set; }
    //}
}
