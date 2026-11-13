using System;
using System.IO;

namespace myHeatingViewer.Helpers
{
    class CSVTools
    {

        /// <summary>
        /// Buffered streaming replacement of target byte sequence with replacement byte sequence.
        /// </summary>
        public static bool ReplaceBytes(string filePath, byte[] target, byte[] replacement, int bufferSize)
        {
            bool answer = false;
            string tempPath = filePath + ".tmp";

            using (FileStream input = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (FileStream output = new FileStream(tempPath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[bufferSize];
                byte[] carryOver = new byte[target.Length - 1]; // store partial match from previous chunk
                int carryLen = 0;

                int bytesRead;
                while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    // Combine carryOver + current buffer into one working array
                    byte[] working = new byte[carryLen + bytesRead];
                    Array.Copy(carryOver, 0, working, 0, carryLen);
                    Array.Copy(buffer, 0, working, carryLen, bytesRead);

                    // Process working array
                    int i = 0;
                    while (i < working.Length)
                    {
                        bool match = true;

                        if (i + target.Length <= working.Length)
                        {
                            for (int j = 0; j < target.Length; j++)
                            {
                                if (working[i + j] != target[j])
                                {
                                    match = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            match = false;
                        }

                        if (match)
                        {
                            output.Write(replacement, 0, replacement.Length);
                            i += target.Length;
                        }
                        else
                        {
                            output.WriteByte(working[i]);
                            i++;
                        }
                    }

                    // Save carryOver from end of buffer if partial match possible
                    carryLen = 0;
                    for (int k = 0; k < target.Length - 1 && k < bytesRead; k++)
                    {
                        carryOver[k] = buffer[bytesRead - (target.Length - 1) + k];
                        carryLen++;
                    }
                }

                // Handle leftover carryOver bytes
                if (carryLen > 0)
                {
                    output.Write(carryOver, 0, carryLen);
                }

                answer = true;
            }

            // Replace original file with temp file
            File.Delete(filePath);
            File.Move(tempPath, filePath);

            return answer;
        }

        /// <summary>
        /// Processes CSV file: removes last two columns and reorders remaining columns.
        /// </summary>
        public void ProcessCsv(string filePath)
        {
            string tempPath = filePath + ".tmp";

            using (var reader = new StreamReader(filePath))
            using (var writer = new StreamWriter(tempPath))
            {
                bool isHeader = true;

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] cols = line.Split(',');

                    // Remove last two columns if they exist
                    if (cols.Length > 6)
                    {
                        Array.Resize(ref cols, cols.Length - 2);
                    }

                    if (isHeader)
                    {
                        // Write new header order
                        writer.WriteLine("Date,Time,Set Temp,Actual Temp,Church sensor,State");
                        isHeader = false;
                    }
                    else
                    {
                        // Expected original order after removal:
                        // Set Temp, Actual Temp, Date, Time, State, Church sensor
                        // Desired order: Date, Time, Set Temp, Actual Temp, Church sensor, State
                        if (cols.Length >= 6)
                        {
                            string[] reordered = new string[]
                            {
                                cols[2], // Date
                                cols[3], // Time
                                cols[0], // Set Temp
                                cols[1], // Actual Temp
                                cols[5], // Church sensor
                                cols[4]  // State
                            };
                            writer.WriteLine(string.Join(",", reordered));
                        }
                    }
                }
            }

            // Replace original file with temp file
            File.Delete(filePath);
            File.Move(tempPath, filePath);
        }

    }
}
