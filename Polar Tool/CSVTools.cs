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

        //
        // define the writer class.  returns the number of tokens written.
        //
        public int CSVWrite(List<List<String>> data)
        {
            String fileName;
            int items = 0;

            // Displays a SaveFileDialog so the user can save the csv file
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "CSV File|*.csv|Polar File|*.pol|Text File|*.txt";
            saveFileDialog1.Title = "Save a CSV File";
            saveFileDialog1.ShowDialog();

            fileName = saveFileDialog1.FileName;

            // If the file name is not an empty string open it for saving.
            if (fileName == "")
            {
                return 0;
            }

            // Saves the Polar data via a FileStream created by the OpenFile method.
            FileStream fs = (FileStream)saveFileDialog1.OpenFile();
            StreamWriter sw = new StreamWriter(fs);

            // Write and display lines from the data until the end of
            // the data is reached.
            try
            {
                //Debug.WriteLine("CSVWrite processing file " + fileName);
                items = 0;

                foreach (var list in data)
                {
                    foreach (var token in list)
                    {
                        items++;
                        sw.Write(token + ",");
                        //Debug.Write(token + ",");
                    }
                    sw.WriteLine();
                    //Debug.WriteLine();
                }
                sw.Flush();
                sw.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Writestream returned error " + e.Message, " in CSVWrite.");
                throw;
            }

            fs.Close();
            return items;
        }

        // this is the reader.  it explicitly trims and filters the input.
        // if the incoming data is not true csv data or is delimited by spaces,
        // it may or may not work correctly, but seems to work OK in that case.
        // it would be much better if the data was filtered to insert comma's or
        // something instead of spaces.

        //  CSV does not have a universal comment character, so this is not yet
        //  implemented.  However, I am considering use a * for a comment.  This
        //  is not yet implemented.

        public List<List<string>> CSVRead(out String fileName)
        {
            List<string[]> parsedData = new List<string[]>();
            String[] fields;
            DialogResult dialogStatus;
            int lineCount;
            List<List<String>> CSVData = new List<List<String>>();
            List<String> t_string = new List<String>();

            // Displays a openFileDialog so can open the polar file
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "CSV files(*.csv, *.txt, *.pol)|*.csv;*.txt;*.pol|All files(*.*)|*.*";
            openFileDialog1.Title = "Open a CSV File";
            dialogStatus = openFileDialog1.ShowDialog();

            if (dialogStatus == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
            }
            else
            {
                // need error handling here
                MessageBox.Show(openFileDialog1.FileName.ToString() + " can not be opened.");
                fileName = "";
                return null;
            }

            // initialize variables
            actRows = 0;
            actCols = 0;

            try
            {
                File.OpenRead(fileName);
            }
            catch (IOException)
            {
                MessageBox.Show("File IO Error.  Is the file already open in another application?");
            }
            finally
            {
                File.OpenRead(fileName);
            }

            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(fileName))
                {
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    try
                    {
                        // //Debug.WriteLine("CSVRead processing file " + fileName);
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

                            //Debug.Write("Line " + lineCount + ": ");

                            // start a new line
                            t_string.Clear();

                            actCols = 0;
                            // get the data and add it to CSVData
                            foreach (string item in fields)
                            {
                                //Debug.Write(item);
                                // do not add empty items to string
                                if (item != "" && item != null)
                                {
                                    t_string.Add(item);
                                    actCols++;
                                }
                            }

                            CSVData.Add(new List<String>(t_string));
                            //Debug.WriteLine("");
                            //Debug.WriteLine(CSVData[lineCount]);
                            lineCount++;
                        }  // while not eod

                        actRows = lineCount;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Parser returned error " + e.Message, " in CSVRead.");
                        throw;
                    }
                    // close the streamreader
                    sr.Close();
                }
            }
            catch (Exception)
            {
                // Let the user know what went wrong.
                //Debug.WriteLine("The file could not be read:");
                //Debug.WriteLine(e.Message);
            }
            return CSVData;
        }
    }
}