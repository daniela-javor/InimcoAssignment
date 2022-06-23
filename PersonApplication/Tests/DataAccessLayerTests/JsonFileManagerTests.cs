using DataAccessLayer;
using DataAccessLayer.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using System.Threading.Tasks;
using Xunit;

namespace DataAccessLayerTests
{
    /// <summary>
    /// JsonFileManager unit tests class.
    /// </summary>
    public class JsonFileManagerTests
    {
        const string path = "C:\\temp\\in.out.txt";
        readonly MockFileSystem _mockFileSystem;
        readonly Person _testPerson;

        public JsonFileManagerTests()
        {
            _mockFileSystem = new MockFileSystem();
            _testPerson = CreateTestPerson();
        }

        /// <summary>
        /// Tests saving person to existing empty file.
        /// </summary>
        /// <returns>Async task.</returns>
        [Fact]
        public async Task SavePersonToEmptyFileTest()
        {
            List<Person> list = new() { _testPerson };
            var mockInputFile = new MockFileData("");
            _mockFileSystem.AddFile(path, mockInputFile);
            
            JsonFileManager<Person> jsonFileManager = new JsonFileManager<Person>(_mockFileSystem, path);
            await jsonFileManager.SaveEntity(_testPerson);

            string expectedFileContent = JsonConvert.SerializeObject(list, Formatting.Indented);
            string fileContent = _mockFileSystem.GetFile(path).TextContents;
            Assert.Equal(expectedFileContent, fileContent);
        }

        /// <summary>
        /// Tests saving person to non existing file.
        /// </summary>
        /// <returns>Async task</returns>
        [Fact]
        public async Task SavePersonToNewFileTest()
        {
            List<Person> list = new() { _testPerson };

            JsonFileManager<Person> jsonFileManager = new JsonFileManager<Person>(_mockFileSystem, path);
            await jsonFileManager.SaveEntity(_testPerson);

            string expectedFileContent = JsonConvert.SerializeObject(list, Formatting.Indented);
            string fileContent = _mockFileSystem.GetFile(path).TextContents;
            Assert.Equal(expectedFileContent, fileContent);  
        }

        /// <summary>
        /// Tests saving person to file with existing person list.
        /// </summary>
        /// <returns>Async task</returns>
        [Fact]
        public async Task SavePersonToExistingListTest()
        {
            List<Person> list = GenerateExistingData();
            var mockInputFile = new MockFileData(JsonConvert.SerializeObject(list, Formatting.Indented));
            _mockFileSystem.AddFile(path, mockInputFile);
            list.Add(_testPerson);

            JsonFileManager<Person> jsonFileManager = new JsonFileManager<Person>(_mockFileSystem, path);
            await jsonFileManager.SaveEntity(_testPerson);

            string expectedFileContent = JsonConvert.SerializeObject(list, Formatting.Indented);
            string fileContent = _mockFileSystem.GetFile(path).TextContents;
            Assert.Equal(expectedFileContent, fileContent);
        }

        /// <summary>
        /// Creates test person for saving.
        /// </summary>
        /// <returns>Generated test person.</returns>
        private Person CreateTestPerson()
        {
            return new Person()
            {
                FirstName = "First name 1",
                LastName = "Last name 1",
                SocialSkills = new List<string>()
                    {
                        "Test skill 1",
                        "Test skill 2",
                        "Test skill 3"
                    },
                SocialAccounts = new List<SocialAccount>()
                    {
                        new SocialAccount()
                        {
                            Type = "Test type 1",
                            Address = "Test address 1"
                        },
                        new SocialAccount()
                        {
                            Type = "Test type 2",
                            Address = "Test address 2"
                        }
                    }
            };
        }

        /// <summary>
        /// Generates existing person list.
        /// </summary>
        /// <returns>Generated person list.</returns>
        private List<Person> GenerateExistingData()
        {
            return new List<Person>()
            {
                new Person()
                {
                    FirstName = "First name 2",
                    LastName = "Last name 2",
                    SocialSkills = new List<string>()
                        {
                            "Test skill 1",
                            "Test skill 2"
                        },
                    SocialAccounts = new List<SocialAccount>()
                        {
                            new SocialAccount()
                            {
                                Type = "Test type 1",
                                Address = "Test address 1"
                            },
                            new SocialAccount()
                            {
                                Type = "Test type 2",
                                Address = "Test address 2"
                            },
                            new SocialAccount()
                            {
                                Type = "Test type 2",
                                Address = "Test address 2"
                            }
                        }
                },
                new Person()
                {
                    FirstName = "First name 3",
                    LastName = "Last name 3",
                    SocialSkills = new List<string>()
                        {
                            "Test skill 1",
                            "Test skill 2",
                            "Test skill 3",
                            "Test skill 4"
                        },
                    SocialAccounts = new List<SocialAccount>()
                        {
                            new SocialAccount()
                            {
                                Type = "Test type 1",
                                Address = "Test address 1"
                            }
                        }
                },
                new Person()
                {
                    FirstName = "First name 4",
                    LastName = "Last name 4",
                    SocialSkills = new List<string>()
                        {
                            "Test skill 1"
                        },
                    SocialAccounts = new List<SocialAccount>()
                        {
                            new SocialAccount()
                            {
                                Type = "Test type 1",
                                Address = "Test address 1"
                            },
                            new SocialAccount()
                            {
                                Type = "Test type 2",
                                Address = "Test address 2"
                            },
                            new SocialAccount()
                            {
                                Type = "Test type 3",
                                Address = "Test address 3"
                            }
                            ,
                            new SocialAccount()
                            {
                                Type = "Test type 4",
                                Address = "Test address 4"
                            },
                            new SocialAccount()
                            {
                                Type = "Test type 5",
                                Address = "Test address 5"
                            }
                        }
                }
            };
        }
    }
}