
using Indian_State_Census_Analyzer;
using Indian_State_Census_Analyzer.POCO;
using static Indian_State_Census_Analyzer.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static readonly string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static readonly string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static readonly string indianStateCensusFilePath = @"C:\Users\aksha\Assignments\Indian-State-Census-Analyzer\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.csv";
        static readonly string indianStateCodeFilePath = @"C:\Users\aksha\Assignments\Indian-State-Census-Analyzer\CensusAnalyserTest\CSVFiles\IndiaStateCode.csv";
        static readonly string wrongHeaderIndianCensusFilePath = @"C:\Users\aksha\Assignments\Indian-State-Census-Analyzer\CensusAnalyserTest\CSVFiles\WrongIndiaStateCensusData.csv";
        static readonly string delimiterIndianCensusFilePath = @"C:\Users\aksha\Assignments\Indian-State-Census-Analyzer\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static readonly string wrongIndianStateCensusFileType = @"C:\Users\aksha\Assignments\Indian-State-Census-Analyzer\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.txt";
        static readonly string wrongIndianStateCodeFileType = @"C:\Users\aksha\Assignments\Indian-State-Census-Analyzer\CensusAnalyserTest\CSVFiles\IndiaStateCode.txt";
        static readonly string delimiterIndianStateCodeFilePath = @"C:\Users\aksha\Assignments\Indian-State-Census-Analyzer\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCode.csv";
        static readonly string wrongHeaderStateCodeFilePath = @"C:\Users\aksha\Assignments\Indian-State-Census-Analyzer\CensusAnalyserTest\CSVFiles\WrongIndiaStateCode.csv";
        static readonly string wrongIndianStateCensusFilePath = @"C:\Users\aksha\Assignments\Indian-State-Census-Analyzer\CensusAnalyserTest\CSVFiles\IndiaData.csv";

        CensusAnalyser censusAnalyser;

        Dictionary<string, CensusDTO> totalRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// Test Case 1.1
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenReade_ThenShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        /// <summary>
        /// Test Case 1.2 
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenIncorrect_ThenShouldReturnFileNotFoundException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }

        /// <summary>
        /// Test Case 1.3 
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFileCorrect_WhenFileTypeIncorrect_ThenShouldReturnInvalidFileTypeException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }

        /// <summary>
        /// Test Case 1.4
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFileCorrect_WhenDelimiterIncorrect_ThenShouldReturnInvalidDelimiterException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }

        /// <summary>
        /// Test Case 1.5
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFileCorrect_WhenHeaderIncorrect_ThenShouldReturnInvalidHeaderException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
    }
}