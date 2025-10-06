using System.Text.RegularExpressions;

namespace Exercise_5
{
    public class Exercise_5
    {
        /*** EXERCISE 5 ***/
        public void ReadAndNormalizeCsFiles(string folderPath)
        {
            foreach (var csFile in Directory.GetFiles(folderPath, "*.cs", SearchOption.AllDirectories))
            {
                string fileContent = File.ReadAllText(csFile);

                if (string.IsNullOrWhiteSpace(fileContent))
                    return;

                string contentNormalized = NormalizeFileContent(fileContent);

                if (fileContent != contentNormalized)
                    File.WriteAllText(csFile, contentNormalized);
            }
        }

        public string NormalizeFileContent(string fileContent)
        {
            return AddBlankLineBetweenMethods(CheckUppercases(CheckAsyncMethodNames(fileContent)));
        }

        private string CheckAsyncMethodNames(string fileContent)
        {
            return Regex.Replace(fileContent, @"(?<signature>async\s+(?:Task|ValueTask)(?:<[^>]+>)?\s+)(?<methodName>\w+)(?<restOfCode>\s*\()",
                m =>
                {
                    var methodName = m.Groups["methodName"].Value;

                    if (!methodName.EndsWith("Async"))
                        methodName += "Async";

                    return m.Groups["signature"].Value + methodName + m.Groups["restOfCode"].Value;
                }
            );
        }

        private string CheckUppercases(string fileContent)
        {
            string result = fileContent;
            result = Regex.Replace(result, @"Vm", "VM");
            result = Regex.Replace(result, @"Vms", "VMs");
            result = Regex.Replace(result, @"Dto", "DTO");
            result = Regex.Replace(result, @"Dtos", "DTOs");

            return result;
        }

        private string AddBlankLineBetweenMethods(string fileContent)
        {
            return Regex.Replace(fileContent, @"(?<endMethod>\}\s*)(?<startMethod>\n\s*(?:public|private|protected|internal))",
                m => m.Groups["endMethod"].Value.Trim() + "\r\n\r\n" + m.Groups["startMethod"].Value.Replace("\n", ""));
        }
    }
}
