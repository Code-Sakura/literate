using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Literate
{
    class Program
    {
        static bool ReplaceExtension(out string dst, string src, string newExt)
        {
            string directory = Path.GetDirectoryName(src) ?? "";
            string filenameWithoutExt = Path.GetFileNameWithoutExtension(src);
            if (string.IsNullOrEmpty(filenameWithoutExt))
            {
                dst = "";
                return false;
            }

            dst = Path.Combine(directory, filenameWithoutExt + newExt);
            return true;
        }

        static void Main()
        {
            Console.Write("Enter input image file path: ");
            string inputFilename = Console.ReadLine() ?? "";

            if (!File.Exists(inputFilename))
            {
                Console.Error.WriteLine($"File not found: {inputFilename}");
                return;
            }

            if (!ReplaceExtension(out string outputFilename, inputFilename, ".png"))
            {
                Console.Error.WriteLine("Failed to create output filename.");
                return;
            }

            try
            {
                using (Image img = Image.FromFile(inputFilename))
                {
                    img.Save(outputFilename, ImageFormat.Png);
                }

                File.Delete(inputFilename);
                Console.WriteLine($"Successfully converted {inputFilename} to {outputFilename}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}