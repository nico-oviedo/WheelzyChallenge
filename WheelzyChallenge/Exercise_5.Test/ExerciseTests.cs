namespace Exercise_5.Test
{
    public class ExerciseTests
    {
        private readonly Exercise_5 exercise_5;

        public ExerciseTests()
        {
            exercise_5 = new Exercise_5();
        }

        [Fact]
        public void NormalizeFileContent_ShouldAddAsyncSuffix()
        {
            string fileContent = @"
                public class FilesProcessor
                {
                    public async Task<bool> ProcessFiles()
                    {
                    }

                    public async Task ReadFilesAsync()
                    {
                    }
                }";

            string expected = @"
                public class FilesProcessor
                {
                    public async Task<bool> ProcessFilesAsync()
                    {
                    }

                    public async Task ReadFilesAsync()
                    {
                    }
                }";

            string result = exercise_5.NormalizeFileContent(fileContent);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("public class UserVm {}", "public class UserVM {}")]
        [InlineData("public class UsersVms {}", "public class UsersVMs {}")]
        [InlineData("public class CustomerDto {}", "public class CustomerDTO {}")]
        [InlineData("public class BuyerDtos {}", "public class BuyerDTOs {}")]
        public void NormalizeFileContent_CheckUppercases(string fileContent, string expected)
        {
            string result = exercise_5.NormalizeFileContent(fileContent);
            Assert.Equal(expected, result);
        }


        [Fact]
        public void NormalizeFileContent_AddBlankLineBetweenMethods()
        {
            string fileContent = @"
                public class FilesProcessor
                {
                    public void ReadFile()
                    {
                    }
                    public void WriteNewFile()
                    {
                    }
                    public void OverwriteFile()
                    {
                    }
                }";

            string expected = @"
                public class FilesProcessor
                {
                    public void ReadFile()
                    {
                    }

                    public void WriteNewFile()
                    {
                    }

                    public void OverwriteFile()
                    {
                    }
                }";

            string result = exercise_5.NormalizeFileContent(fileContent);
            Assert.Equal(expected, result);
        }
    }
}
