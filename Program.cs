using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conappfilehandlingassi10
{
    public class Operations
    {
        static void CreateFile(string fileName, string content)
        {
            try
            {
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.Write(content);
                }
                Console.WriteLine($"File '{fileName}' created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while creating the file: {ex.Message}");
            }
        }

        static void ReadFile(string fileName)
        {
            try
            {
                string content = File.ReadAllText(fileName);
                Console.WriteLine($"Content of file '{fileName}':\n{content}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File '{fileName}' not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while reading the file: {ex.Message}");
            }
        }

        static void AppendToFile(string fileName, string content)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(fileName))
                {
                    sw.Write(content);
                }
                Console.WriteLine($"Content appended to file '{fileName}' successfully.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File '{fileName}' not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while appending to the file: {ex.Message}");
            }
        }

        static void DeleteFile(string fileName)
        {
            try
            {
                File.Delete(fileName);
                Console.WriteLine($"File '{fileName}' deleted successfully.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File '{fileName}' not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while deleting the file: {ex.Message}");
            }

        }
        internal class Program
        {
            static void Main(string[] args)
            {
                while (true)
                {
                    Console.WriteLine("Choose operation:");
                    Console.WriteLine("1. Create");
                    Console.WriteLine("2. Read");
                    Console.WriteLine("3. Append");
                    Console.WriteLine("4. Delete");
                    Console.WriteLine("5. Exit");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter file name: ");
                            string createFileName = Console.ReadLine();
                            Console.Write("Enter file content: ");
                            string content = Console.ReadLine();
                            CreateFile(createFileName, content);
                            break;

                        case 2:
                            Console.Write("Enter file name to read: ");
                            string readFileName = Console.ReadLine();
                            ReadFile(readFileName);
                            break;

                        case 3:
                            Console.Write("Enter file name to append: ");
                            string appendFileName = Console.ReadLine();
                            Console.Write("Enter content to append: ");
                            string appendContent = Console.ReadLine();
                            AppendToFile(appendFileName, appendContent);
                            break;

                        case 4:
                            Console.Write("Enter file name to delete: ");
                            string deleteFileName = Console.ReadLine();
                            DeleteFile(deleteFileName);
                            break;

                        case 5:
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;

                    }

                    Console.WriteLine("Press any key to continue....");
                    Console.ReadKey();

                }
            }

        }
    }
}