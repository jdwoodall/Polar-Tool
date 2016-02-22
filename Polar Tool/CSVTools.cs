using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CSVTools
{
    public class CSVTools
    {

        public int actRows { get; private set; }
        public int actCols { get; private set; }

        public List<List<string>> CSVRead(string filename)
        {
            List<string[]> parsedData = new List<string[]>();
            String[] fields;

            int lineCount;

            List<List<String>> CSVData = new List<List<String>>();
            List<String> t_string = new List<String>();


            // initialize variables
            actRows = 0;
            actCols = 0;

            // make sure the file exists
            if (!File.Exists(filename))
            {
                MessageBox.Show("File " + filename + "does not exists.", "CSVRead");
                return null;
            }


            try
            {
                File.OpenRead(filename);
            }
            catch (IOException)
            {
                MessageBox.Show("File IO Error.  Is the file already open in another application?");
            }
            finally
            {
                File.OpenRead(filename);
            }

            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(filename))
                {

                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    try
                    {
                        // //Console.WriteLine("CSVRead processing file " + filename);
                        TextFieldParser parser = new TextFieldParser(sr);
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",", ";", "\t", " ");
                        parser.TrimWhiteSpace = true;

                        lineCount = 0;
                        while (!parser.EndOfData)
                        {
                            // read the next line of data
                            fields = parser.ReadFields();
                            parsedData.Add(fields);

                            //Console.Write("Line " + lineCount + ": ");

                            // start a new line
                            t_string.Clear();

                            actCols = 0;
                            // get the data and add it to CSVData
                            foreach (string item in fields)
                            {
                                //Console.Write(item);
                                // do not add empty items to string
                                if (item != "" && item != null)
                                {
                                    t_string.Add(item);
                                    actCols++;
                                }
                            }

                            CSVData.Add(new List<String>(t_string));
                            //Console.WriteLine("");
                            //Console.WriteLine(CSVData[lineCount]);
                            lineCount++;
                        }  // while not eod

                        actRows = lineCount;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Parser returned error " + e.Message, " in CSVRead.");
                        throw;
                    }
                }
            }
            catch (Exception)
            {
                // Let the user know what went wrong.
                //Console.WriteLine("The file could not be read:");
                //Console.WriteLine(e.Message);
            }
            return CSVData;
        }
    }
}
