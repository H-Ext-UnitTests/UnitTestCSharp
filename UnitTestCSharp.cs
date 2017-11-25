
// List of API support

// List of EXTs API support for all modes

//#define EXT_IUTIL
//#define EXT_ICOMMAND
//#define EXT_ICINIFILE
//#define EXT_ITIMER
//#define EXT_HKTIMER

// List of EXTs API support for mp mode only

//#define EXT_IHALOENGINE
//#define EXT_IOBJECT         // Require EXT_IUTIL
//#define EXT_IPLAYER         // Require EXT_IOBJECT; if define EXT_IADMIN, EXT_IPLAYER test will not process
//#define EXT_IADMIN          // Require EXT_IUTIL

// Not included in this UnitTest.
//#define EXT_IDATABASE
//#define EXT_IDATABASESTATEMENT
//#define EXT_HKDATABASE

//Future API support

//#define EXT_INETWORK              // Will require mp mode test and possible client?
//#define EXT_ISOUND                // Require client side test only.
//#define EXT_IDIRECTX9             // Require client side test only
//#define EXT_HKEXTERNAL            // TBD

#if DO_NOT_INCLUDE_THIS
addon_info EXTPluginInfo = { "UnitTest C Sharp", "1.0.0.0",
                            "DZS|All-In-One, founder of DZS",
                            "Used for verifying each API are working right in C# language under C99 standard.",
                            "UnitTest",
                            "unit_test",
                            "test_unit",
                            "unit test",
                            "[unit]test",
                            "test[unit]"};
#endif

/*
 * Verification list as of 0.5.3.4
 *
 * EXT_IHALOENGINE          - Passed (except a few functions are not included in test.)
 * EXT_IOBJECT              - Passed (except a few functions are not included in test.)
 * EXT_IPLAYER              - Passed (except a few functions are not included in test.)
 * EXT_IADMIN               - Passed
 * EXT_ICOMMAND             - Passed
 * EXT_IDATABASE            - Not included in this UnitTest.
 * EXT_IDATABASESTATEMENT   - Not included in this UnitTest.
 * EXT_HKDATABASE           - Not included in this UnitTest.
 * EXT_ICINIFILE            - Passed
 * EXT_ITIMER               - Passed (Expect imbalance tick synchronize for 1/30 ticks per second after first load time.)
 * EXT_HKTIMER              - Passed
 * EXT_IUTIL                - Passed (except a few functions are not included in test.)
 * Future API support
 * EXT_INETWORK
 * EXT_ISOUND
 * EXT_IDIRECTX9
 * EXT_HKEXTERNAL
 */

/*
 * This link is for effective usage in unmanaged code (not for C# code) to load managed dll.
 * http://stackoverflow.com/questions/773476/how-to-split-dot-net-hosting-function-when-calling-via-c-dll
 */

using System;
using System.Text;
using System.Windows.Forms;

using RGiesecke.DllExport;
using System.Runtime.InteropServices;

namespace UnitTestCSharp {
    public class Addon {
        public static uint hash;
#if EXT_IUTIL
        //boolean test section
        public static string trueStr = "true";
        public static string TRUEStr = "TRUE";
        public static string trUeStr = "trUe";
        public static string trueNumStr = "1";
        public static string falseStr = "false";
        public static string FALSEStr = "FALSE";
        public static string faLseStr = "faLse";
        public static string falseNumStr = "0";

        //team test section
        public static string blueStr = "blue";
        public static string BLUEStr = "BLUE";
        public static string btStr = "bt";
        public static string redStr = "red";
        public static string REDStr = "RED";
        public static string rtStr = "rt";

        //detect string test section
        public static string lettersStr = "lEtteRs";
        public static string letters2Str = "LeTterS";
        public static string numbersStr = "12348765";
        public static string numbers2Str = "87651234";
        public static string floatStr = "1234.8765";
        public static string doubleStr = "1.2348765";
        public static string hashStr = "87a651234";
        public static string hash2Str = "876512z34";

        public static string MatterStr = "Matter";
        public static string MattarStr = "Mattar";
        public static string MattarReplaceBeforeStr = "MattarTest 'Foobar'";
        public static string MatterReplaceBeforeStr = "MatterTest 'Foobar'";

        //directory and file test section
        public static string dirExtension = "extension";
        public static string fileHExt = "H-Ext.dll";
        public static string dirExtesion = "extesion";
        public static string fileHEt = "H-Et.dll";

        public static StringBuilder replaceTestStr = new StringBuilder("Test 'Foobar'");
        public static string replaceBeforeStr = "Test 'Foobar'";
        public static string replaceAfterStr = "Test ''Foobar''";

        //regex test section
        public static StringBuilder regexTestNoDB = new StringBuilder("? *? {test} )(string]here[there", 40);
        public static string regexTestNoDBAfter = ". .*. \\{test\\} \\)\\(string\\]here\\[there";
        public static StringBuilder regexTestDB = new StringBuilder("? *? {test} )(string]here[there", 40);
        public static string regexTestDBAfter = "_ %_ \\{test\\} \\)\\(string\\]here\\[there";
        public static string wildcard = ".*";
        public static string wildcardEndTest = ".*Test";
        public static string wildcardBeginUnit = "Unit .*";
        public static string dotdotdot = "...";
        public static string hi_ = "Hi!";
        public static string Unit_Test = "Unit Test";
        public static string unit_test = "unit test";

        //variant test section - CSharp only provide unicode input, absolutely no ansi support at all.
        //public static string variantFormatExpected = "Aa 1.000000 2.000002 1 25 50 4294967295 2147483647 2147483647 4294967295 aA";
        //public static string variantFormat = "{0:s} {2:f} {3:f} {4:hhd} {5:hd} {6:hu} {8:u} {7:d} {9:ld} {10:lu} {1:s}";
        public static string variantFormatExpected = "1.000000 2.000002 1 25 50 4294967295 2147483647 2147483647 4294967295 aA";
        public static string variantFormat = "{2:f} {3:f} {4:hhd} {5:hd} {6:hu} {8:u} {7:d} {9:ld} {10:lu} {1:s}";
#endif
#if EXT_ICOMMAND || EXT_ICINIFILE
        public static Addon_API.addon_section_names sectors = new Addon_API.addon_section_names() { 
                                                        sect_name1="unit_test",
                                                        sect_name2="test_unit",
                                                        sect_name3="unit test",
                                                        sect_name4="[unit]test",
                                                        sect_name5="test[unit]" };
#endif
#if EXT_ICINIFILE
        public static string iniFileStr = "UnitTestC.ini";
        public static string firstUnitTestCStr = "First Unit Test C";
        public static string str1_0 = "1.0";
        public static string str1_1 = "1.1";
        public static string str1_2 = "1.2";
        public static string str1_3 = "1.3";
        public static string iniFileDataStr = " [unit_test]\r\n 1.0=First Unit Test C\r\n [test_unit]\r\n 1.1=First Unit Test C\r\n [unit test]";
#endif

        //ICommand test section
#if EXT_ICOMMAND
        public static string eaoTestExecuteStr = "eao_test_execute";
        public static string eaoTestExecuteAliasStr = "testexec";
        public static string eaoLoadFileStr = "unit_test.txt";
        //This is needed in order to preserve function pointer address
        public static Addon_API.CmdFunc eao_testExecutePtr;
        public static Addon_API.CmdFunc eao_testExecuteOverridePtr;
        public static Addon_API.CmdFunc eao_testExecuteOverride2Ptr;
        public static Addon_API.CMD_RETURN eao_testExecute([In] Addon_API.PlayerInfo plI, [In, Out] ref Addon_API.ArgContainerVars arg, [In] Addon_API.MSG_PROTOCOL protocolMsg, [In] uint idTimer, [In] boolOption showChat) {
            return Addon_API.CMD_RETURN.SUCC;
        }
        public static Addon_API.CMD_RETURN eao_testExecuteOverride([In] Addon_API.PlayerInfo plI, [In, Out] ref Addon_API.ArgContainerVars arg, [In] Addon_API.MSG_PROTOCOL protocolMsg, [In] uint idTimer, [In] boolOption showChat) {
            return Addon_API.CMD_RETURN.SUCC;
        }
        public static Addon_API.CMD_RETURN eao_testExecuteOverride2([In] Addon_API.PlayerInfo plI, [In, Out] ref Addon_API.ArgContainerVars arg, [In] Addon_API.MSG_PROTOCOL protocolMsg, [In] uint idTimer, [In] boolOption showChat) {
            return Addon_API.CMD_RETURN.SUCC;
        }
#endif
        //IPlayer test section
#if EXT_IPLAYER
        public static StringBuilder cdHashKeyA = new StringBuilder(0x60);
#endif
        //IAdmin test section
#if EXT_IADMIN
        public static string username = "unittest";
        public static string usernamebad = "unittes";
        public static string cmdEaoLoad = "ext_addon_load unittest";
        public static string noKeyHere = "nokeyhere";
        public static string localhost = "127.0.0.1";
#endif
        //ITimer test section
#if EXT_ITIMER
        public static Addon_API.ITimer pITimer;
        public static uint[] TimerID = { 0, 0, 0, 0 };
        public static uint TimerTickStart = 0;
        public static uint[] TimerTickSys = { 0, 0, 0, 0 };
#endif
        //IHaloEngine test section
#if EXT_IHALOENGINE
        public static string rconTestStr = "Rcon Test";
        public static string playerChatTest = "Player Chat Test";
        public static string globalChatTest = "Global Chat Test";
        public static string password = "unitest";
        public static StringBuilder passwordWGet = new StringBuilder("deadbeef", 8);
        public static StringBuilder passwordAGet = new StringBuilder("deadbeef", 8);
#endif
        [DllExport("EXTOnEAOLoad", CallingConvention = CallingConvention.Cdecl)]
        public static Addon_API.EAO_RETURN EXTOnEAOLoad(uint uniqueHash) {
            hash = uniqueHash;
            uint retCode;
            IntPtr testPtr = IntPtr.Zero;
            Addon_API.PlayerInfo plI = new Addon_API.PlayerInfo(), plIKeep = new Addon_API.PlayerInfo(), plINull = new Addon_API.PlayerInfo();
            #region IUtil test section
#if EXT_IUTIL
            Addon_API.IUtil pIUtil = Addon_API.Interface.getIUtil(hash);
            try {
                if (pIUtil.isNotNull()) {
                    Addon_API.Global.pIUtil = pIUtil;
                    //m_allocMem & m_freeMem functions are not needed here.
                    StringBuilder testBStrW = new StringBuilder(0x30);
                    StringBuilder testBStrA = new StringBuilder(0x30);
                    string testStr1 = "Test String";
                    StringBuilder matterStr = new StringBuilder("Matter");
                    if (pIUtil.m_strcatW(testBStrW, (uint)testBStrW.Capacity, testStr1) != 11)
                        throw new ArgumentException();
                    if (!pIUtil.m_strcmpW(testBStrW.ToString(), testStr1))
                        throw new ArgumentException();
                    if (pIUtil.m_strcatA(testBStrA, (uint)testBStrA.Capacity, testStr1) != 11)
                        throw new ArgumentException();
                    if (!pIUtil.m_strcmpA(testBStrA.ToString(), testStr1))
                        throw new ArgumentException();
            #region boolean values
                    if (pIUtil.m_strToBooleanW(testBStrW.ToString()) != Addon_API.e_boolean.FAIL)
                        throw new ArgumentException();
                    if (pIUtil.m_strToBooleanA(testBStrA.ToString()) != Addon_API.e_boolean.FAIL)
                        throw new ArgumentException();
                    if (pIUtil.m_strToBooleanW(trueStr) != Addon_API.e_boolean.TRUE)
                        throw new ArgumentException();
                    if (pIUtil.m_strToBooleanW(TRUEStr) != Addon_API.e_boolean.TRUE)
                        throw new ArgumentException();
                    if (pIUtil.m_strToBooleanW(trUeStr) != Addon_API.e_boolean.TRUE)
                        throw new ArgumentException();
                    if (pIUtil.m_strToBooleanW(trueNumStr) != Addon_API.e_boolean.TRUE)
                        throw new ArgumentException();
                    if (pIUtil.m_strToBooleanW(falseStr) != Addon_API.e_boolean.FALSE)
                        throw new ArgumentException();
                    if (pIUtil.m_strToBooleanW(FALSEStr) != Addon_API.e_boolean.FALSE)
                        throw new ArgumentException();
                    if (pIUtil.m_strToBooleanW(faLseStr) != Addon_API.e_boolean.FALSE)
                        throw new ArgumentException();
                    if (pIUtil.m_strToBooleanW(falseNumStr) != Addon_API.e_boolean.FALSE)
                        throw new ArgumentException();
                    if (pIUtil.m_strToBooleanA(trueStr) != Addon_API.e_boolean.TRUE)
                        throw new ArgumentException();
                    if (pIUtil.m_strToBooleanA(TRUEStr) != Addon_API.e_boolean.TRUE)
                        throw new ArgumentException();
                    if (pIUtil.m_strToBooleanA(trUeStr) != Addon_API.e_boolean.TRUE)
                        throw new ArgumentException();
                    if (pIUtil.m_strToBooleanA(trueNumStr) != Addon_API.e_boolean.TRUE)
                        throw new ArgumentException();
                    if (pIUtil.m_strToBooleanA(falseStr) != Addon_API.e_boolean.FALSE)
                        throw new ArgumentException();
                    if (pIUtil.m_strToBooleanA(FALSEStr) != Addon_API.e_boolean.FALSE)
                        throw new ArgumentException();
                    if (pIUtil.m_strToBooleanA(faLseStr) != Addon_API.e_boolean.FALSE)
                        throw new ArgumentException();
                    if (pIUtil.m_strToBooleanA(falseNumStr) != Addon_API.e_boolean.FALSE)
                        throw new ArgumentException();
            #endregion
            #region team values
                    if (pIUtil.m_strToTeamW(testBStrW.ToString()) != e_color_team_index.TEAM_NONE)
                        throw new ArgumentException();
                    if (pIUtil.m_strToTeamA(testBStrA.ToString()) != e_color_team_index.TEAM_NONE)
                        throw new ArgumentException();
                    if (pIUtil.m_strToTeamW(blueStr) != e_color_team_index.TEAM_BLUE)
                        throw new ArgumentException();
                    if (pIUtil.m_strToTeamW(BLUEStr) != e_color_team_index.TEAM_BLUE)
                        throw new ArgumentException();
                    if (pIUtil.m_strToTeamW(btStr) != e_color_team_index.TEAM_BLUE)
                        throw new ArgumentException();
                    if (pIUtil.m_strToTeamW(redStr) != e_color_team_index.TEAM_RED)
                        throw new ArgumentException();
                    if (pIUtil.m_strToTeamW(REDStr) != e_color_team_index.TEAM_RED)
                        throw new ArgumentException();
                    if (pIUtil.m_strToTeamW(rtStr) != e_color_team_index.TEAM_RED)
                        throw new ArgumentException();
                    if (pIUtil.m_strToTeamA(blueStr) != e_color_team_index.TEAM_BLUE)
                        throw new ArgumentException();
                    if (pIUtil.m_strToTeamA(BLUEStr) != e_color_team_index.TEAM_BLUE)
                        throw new ArgumentException();
                    if (pIUtil.m_strToTeamA(btStr) != e_color_team_index.TEAM_BLUE)
                        throw new ArgumentException();
                    if (pIUtil.m_strToTeamA(redStr) != e_color_team_index.TEAM_RED)
                        throw new ArgumentException();
                    if (pIUtil.m_strToTeamA(REDStr) != e_color_team_index.TEAM_RED)
                        throw new ArgumentException();
                    if (pIUtil.m_strToTeamA(rtStr) != e_color_team_index.TEAM_RED)
                        throw new ArgumentException();
            #endregion
            #region Strings values verification
                    testBStrA.Remove(0, testBStrA.Length);
                    pIUtil.m_toCharA(testBStrW.ToString(), testBStrW.Length + 1, testBStrA);
                    if (!pIUtil.m_strcmpA(testStr1, testBStrA.ToString()))
                        throw new ArgumentException();
                    pIUtil.m_toCharW(testBStrA.ToString(), testBStrA.Length + 1, testBStrW);
                    if (!pIUtil.m_strcmpW(testStr1, testBStrW.ToString()))
                        throw new ArgumentException();
                    testBStrA.Replace('t', 'T');
                    testBStrW.Replace('t', 'T');
                    if (!pIUtil.m_stricmpA(testStr1, testBStrA.ToString()))
                        throw new ArgumentException();
                    testBStrW.Remove(0, testBStrW.Length);
                    pIUtil.m_toCharW(testBStrA.ToString(), testBStrA.Length + 1, testBStrW);
                    if (!pIUtil.m_stricmpW(testStr1, testBStrW.ToString()))
                        throw new ArgumentException();
                    testBStrA.Replace('T', 't');
                    testBStrW.Replace('T', 't');
                    if (!pIUtil.m_stricmpW(lettersStr, letters2Str))
                        throw new ArgumentException();
                    if (!pIUtil.m_stricmpA(lettersStr, letters2Str))
                        throw new ArgumentException();
                    if (pIUtil.m_strcmpW(lettersStr, letters2Str))
                        throw new ArgumentException();
                    if (pIUtil.m_strcmpA(lettersStr, letters2Str))
                        throw new ArgumentException();
                    if (pIUtil.m_stricmpW(numbersStr, numbers2Str))
                        throw new ArgumentException();
                    if (pIUtil.m_stricmpA(numbersStr, numbers2Str))
                        throw new ArgumentException();
                    if (pIUtil.m_strcmpW(numbersStr, numbers2Str))
                        throw new ArgumentException();
                    if (pIUtil.m_strcmpA(numbersStr, numbers2Str))
                        throw new ArgumentException();

                    Addon_API.e_boolean boolean = pIUtil.m_shiftStrW(matterStr, 1, 3, 1, false);
                    if (boolean != Addon_API.e_boolean.TRUE)
                        throw new ArgumentException();
                    if (!pIUtil.m_findSubStrFirstW(matterStr.ToString(), MatterStr))
                        throw new ArgumentException();
                    if (pIUtil.m_findSubStrFirstW(matterStr.ToString(), MattarStr))
                        throw new ArgumentException();
                    boolean = pIUtil.m_shiftStrW(matterStr, 1, 1, 3, true);
                    if (boolean != Addon_API.e_boolean.TRUE)
                        throw new ArgumentException();
                    if (!pIUtil.m_findSubStrFirstW(matterStr.ToString(), MattarStr))
                        throw new ArgumentException();
                    if (pIUtil.m_findSubStrFirstW(matterStr.ToString(), MatterStr))
                        throw new ArgumentException();

                    //No reason to have 2 matter string since ANSII and Unicode are done by C# itself.
                    matterStr.Remove(0, matterStr.Length);
                    matterStr.Insert(0, MatterStr);
                    boolean = pIUtil.m_shiftStrA(matterStr, 1, 3, 1, false);
                    if (boolean != Addon_API.e_boolean.TRUE)
                        throw new ArgumentException();
                    if (!pIUtil.m_findSubStrFirstA(matterStr.ToString(), MatterStr))
                        throw new ArgumentException();
                    if (pIUtil.m_findSubStrFirstA(matterStr.ToString(), MattarStr))
                        throw new ArgumentException();
                    boolean = pIUtil.m_shiftStrA(matterStr, 1, 1, 3, true);
                    if (boolean != Addon_API.e_boolean.TRUE)
                        throw new ArgumentException();
                    if (!pIUtil.m_findSubStrFirstA(matterStr.ToString(), MattarStr))
                        throw new ArgumentException();
                    if (pIUtil.m_findSubStrFirstA(matterStr.ToString(), MatterStr))
                        throw new ArgumentException();

                    testBStrW.Remove(0, testBStrW.Length);
                    testBStrA.Remove(0, testBStrA.Length);
                    retCode = pIUtil.m_strcatW(testBStrW, 48, MattarStr);
                    if (retCode != 6)
                        throw new ArgumentException();
                    retCode = pIUtil.m_strcatA(testBStrA, 48, MatterStr);
                    if (retCode != 6)
                        throw new ArgumentException();
                    if (!pIUtil.m_strcmpW(testBStrW.ToString(), MattarStr))
                        throw new ArgumentException();
                    if (!pIUtil.m_strcmpA(testBStrA.ToString(), MatterStr))
                        throw new ArgumentException();
                    retCode = pIUtil.m_strcatW(testBStrW, 48, replaceBeforeStr);
                    if (retCode != 13)
                        throw new ArgumentException();
                    retCode = pIUtil.m_strcatA(testBStrA, 48, replaceBeforeStr);
                    if (retCode != 13)
                        throw new ArgumentException();
                    if (!pIUtil.m_strcmpW(testBStrW.ToString(), MattarReplaceBeforeStr))
                        throw new ArgumentException();
                    if (!pIUtil.m_strcmpA(testBStrA.ToString(), MatterReplaceBeforeStr))
                        throw new ArgumentException();
            #endregion
            #region isLetters, isFloat, isDouble, isNumbers, and isHash
                    if (!pIUtil.m_isLettersW(lettersStr))
                        throw new ArgumentException();
                    if (pIUtil.m_isLettersW(hashStr))
                        throw new ArgumentException();
                    if (!pIUtil.m_isLettersA(letters2Str))
                        throw new ArgumentException();
                    if (pIUtil.m_isLettersA(hash2Str))
                        throw new ArgumentException();

                    if (!pIUtil.m_isNumberW(numbersStr))
                        throw new ArgumentException();
                    if (pIUtil.m_isNumberW(hashStr))
                        throw new ArgumentException();
                    if (pIUtil.m_isNumberW(floatStr))
                        throw new ArgumentException();
                    if (!pIUtil.m_isNumberA(numbers2Str))
                        throw new ArgumentException();
                    if (pIUtil.m_isNumberW(hash2Str))
                        throw new ArgumentException();
                    if (pIUtil.m_isNumberW(floatStr))
                        throw new ArgumentException();

                    if (!pIUtil.m_isDoubleW(doubleStr))
                        throw new ArgumentException();
                    if (!pIUtil.m_isDoubleW(numbersStr))
                        throw new ArgumentException();
                    if (pIUtil.m_isDoubleW(hashStr))
                        throw new ArgumentException();
                    if (!pIUtil.m_isDoubleW(floatStr))
                        throw new ArgumentException();
                    if (!pIUtil.m_isDoubleA(doubleStr))
                        throw new ArgumentException();
                    if (!pIUtil.m_isDoubleA(numbers2Str))
                        throw new ArgumentException();
                    if (pIUtil.m_isDoubleA(hash2Str))
                        throw new ArgumentException();
                    if (!pIUtil.m_isDoubleA(floatStr))
                        throw new ArgumentException();

                    if (!pIUtil.m_isFloatW(floatStr))
                        throw new ArgumentException();
                    if (pIUtil.m_isFloatW(doubleStr))
                        throw new ArgumentException();
                    if (!pIUtil.m_isFloatW(numbersStr))
                        throw new ArgumentException();
                    if (pIUtil.m_isFloatW(hashStr))
                        throw new ArgumentException();
                    if (!pIUtil.m_isFloatA(floatStr))
                        throw new ArgumentException();
                    if (pIUtil.m_isFloatA(doubleStr))
                        throw new ArgumentException();
                    if (!pIUtil.m_isFloatA(numbers2Str))
                        throw new ArgumentException();
                    if (pIUtil.m_isFloatA(hash2Str))
                        throw new ArgumentException();

                    if (!pIUtil.m_isHashW(hashStr))
                        throw new ArgumentException();
                    if (pIUtil.m_isHashW(floatStr))
                        throw new ArgumentException();
                    if (!pIUtil.m_isHashA(hash2Str))
                        throw new ArgumentException();
                    if (pIUtil.m_isHashA(floatStr))
                        throw new ArgumentException();
            #endregion
            #region file & directory check
                    if (!pIUtil.m_isDirExist(dirExtension, ref retCode))
                        throw new ArgumentException();
                    if (retCode>0)
                        throw new ArgumentException();
                    if (pIUtil.m_isDirExist(dirExtesion, ref retCode))
                        throw new ArgumentException();
                    if (retCode==0)
                        throw new ArgumentException();
                    if (pIUtil.m_isDirExist(fileHExt, ref retCode))
                        throw new ArgumentException();
                    if (retCode == 0)
                        throw new ArgumentException();
                    if (!pIUtil.m_isFileExist(fileHExt, ref retCode))
                        throw new ArgumentException();
                    if (retCode>0)
                        throw new ArgumentException();
                    if (pIUtil.m_isFileExist(fileHEt, ref retCode))
                        throw new ArgumentException();
                    if (retCode == 0)
                        throw new ArgumentException();
                    if (pIUtil.m_isFileExist(dirExtension, ref retCode))
                        throw new ArgumentException();
                    if (retCode == 0)
                        throw new ArgumentException();
            #endregion
            #region Replace & undo relative + database regex replace.
                    pIUtil.m_replaceW(replaceTestStr);
                    if (!pIUtil.m_strcmpW(replaceTestStr.ToString(), replaceAfterStr))
                        throw new ArgumentException();
                    pIUtil.m_replaceUndoW(replaceTestStr);
                    if (!pIUtil.m_strcmpW(replaceTestStr.ToString(), replaceBeforeStr))
                        throw new ArgumentException();
                    pIUtil.m_replaceA(replaceTestStr);
                    if (!pIUtil.m_strcmpA(replaceTestStr.ToString(), replaceAfterStr))
                        throw new ArgumentException();
                    pIUtil.m_replaceUndoA(replaceTestStr);
                    if (!pIUtil.m_strcmpA(replaceTestStr.ToString(), replaceBeforeStr))
                        throw new ArgumentException();

                    pIUtil.m_regexReplaceW(regexTestNoDB, false);
                    if (!pIUtil.m_strcmpW(regexTestNoDB.ToString(), regexTestNoDBAfter))
                        throw new ArgumentException();
                    pIUtil.m_regexReplaceW(regexTestDB, true);
                    if (!pIUtil.m_strcmpW(regexTestDB.ToString(), regexTestDBAfter))
                        throw new ArgumentException();

                    //regex test
                    if (!pIUtil.m_regexMatchW(Unit_Test, wildcard))
                        throw new ArgumentException();
                    if (!pIUtil.m_regexMatchW(Unit_Test, wildcardBeginUnit))
                        throw new ArgumentException();
                    if (!pIUtil.m_regexMatchW(Unit_Test, wildcardEndTest))
                        throw new ArgumentException();
                    if (!pIUtil.m_regexMatchW(unit_test, wildcard))
                        throw new ArgumentException();
                    if (pIUtil.m_regexMatchW(unit_test, wildcardBeginUnit))
                        throw new ArgumentException();
                    if (pIUtil.m_regexMatchW(unit_test, wildcardEndTest))
                        throw new ArgumentException();
                    if (pIUtil.m_regexMatchW(unit_test, dotdotdot))
                        throw new ArgumentException();

                    if (!pIUtil.m_regexMatchW(hi_, dotdotdot))
                        throw new ArgumentException();
                    if (!pIUtil.m_regexiMatchW(hi_, dotdotdot))
                        throw new ArgumentException();
                    if (!pIUtil.m_regexiMatchW(Unit_Test, wildcard))
                        throw new ArgumentException();
                    if (!pIUtil.m_regexiMatchW(Unit_Test, wildcardBeginUnit))
                        throw new ArgumentException();
                    if (!pIUtil.m_regexiMatchW(Unit_Test, wildcardEndTest))
                        throw new ArgumentException();
                    if (!pIUtil.m_regexiMatchW(unit_test, wildcard))
                        throw new ArgumentException();
                    if (!pIUtil.m_regexiMatchW(unit_test, wildcardBeginUnit))
                        throw new ArgumentException();
                    if (!pIUtil.m_regexiMatchW(unit_test, wildcardEndTest))
                        throw new ArgumentException();
                    if (pIUtil.m_regexiMatchW(unit_test, dotdotdot))
                        throw new ArgumentException();
            #endregion
            #region formatVar___ functions
                    object[] testVariant = new object[11];
                    StringBuilder outputString = new StringBuilder(0x512);
                    //TODO: Unable to force ansi string into object as it does not have support for it.
                    //testVariant[0] = new BStrWrapper("Aa"); //Nope, it's set to auto. It actually return unicode / System.Runtime.InteropServices.BStrWrapper
                    //testVariant[0] = Encoding.Default.GetString(Encoding.Default.GetBytes("Aa")); //Nope, still is unicode.
                    testVariant[1] = "aA";
                    testVariant[2] = (float)1.000f;
                    testVariant[3] = (double)2.000002;
                    testVariant[4] = (bool)true;
                    testVariant[5] = (short)25;
                    testVariant[6] = (ushort)50;
                    testVariant[7] = Int32.MaxValue; //MAXINT
                    testVariant[8] = UInt32.MaxValue; //MAXUINT
                    testVariant[9] = (long)0x7fffffff; //MAXLONG
                    testVariant[10] = (ulong)((uint)~((uint)0)); //MAXULONG
                    if (!pIUtil.m_formatVariantW(outputString, (uint)outputString.Capacity, variantFormat, 11, testVariant))
                        throw new ArgumentException();
                    if (!pIUtil.m_strcmpW(variantFormatExpected, outputString.ToString()))
                        throw new ArgumentException();
            #endregion
                    MessageBox.Show("IUtil API has passed unit test.", "PASSED - IUtil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                    throw new ArgumentException();
            } catch(ArgumentException) {
                MessageBox.Show("IUtil API has failed unit test.", "ERROR - IUtil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Addon_API.EAO_RETURN.FAIL;
            }
#endif
            #endregion
            #region ICIniFile test section
#if EXT_ICINIFILE
            Addon_API.ICIniFileClass pICIniFile = Addon_API.Interface.getICIniFile(hash);
            try {
                if (pICIniFile.isNotNull()) {
                    if (pICIniFile.m_open_file(iniFileStr)) {
                        if (!pICIniFile.m_delete_file(iniFileStr))
                            throw new ArgumentException();
                        if (pICIniFile.m_open_file(iniFileStr))
                            throw new ArgumentException();
                    }
                    if (!pICIniFile.m_create_file(iniFileStr))
                        throw new ArgumentException();
                    if (!pICIniFile.m_open_file(iniFileStr))
                        throw new ArgumentException();
                    retCode = 0;
                    recheckICIniFileDataExists:
                    if (pICIniFile.m_section_exist(sectors.sect_name1))
                        throw new ArgumentException();
                    if (pICIniFile.m_section_exist(sectors.sect_name2))
                        throw new ArgumentException();
                    if (pICIniFile.m_section_exist(sectors.sect_name3))
                        throw new ArgumentException();
                    if (pICIniFile.m_section_exist(sectors.sect_name4))
                        throw new ArgumentException();
                    if (pICIniFile.m_section_exist(sectors.sect_name5))
                        throw new ArgumentException();

                    if (pICIniFile.m_key_exist(sectors.sect_name1, str1_0))
                        throw new ArgumentException();
                    if (pICIniFile.m_key_exist(sectors.sect_name2, str1_1))
                        throw new ArgumentException();
                    if (pICIniFile.m_key_exist(sectors.sect_name3, str1_0))
                        throw new ArgumentException();
                    if (pICIniFile.m_key_exist(sectors.sect_name4, str1_2))
                        throw new ArgumentException();
                    if (pICIniFile.m_key_exist(sectors.sect_name5, str1_3))
                        throw new ArgumentException();

                    if (!pICIniFile.m_value_set(sectors.sect_name1, str1_0, firstUnitTestCStr))
                        throw new ArgumentException();
                    if (!pICIniFile.m_value_set(sectors.sect_name2, str1_1, firstUnitTestCStr))
                        throw new ArgumentException();
                    if (!pICIniFile.m_value_set(sectors.sect_name3, str1_0, firstUnitTestCStr))
                        throw new ArgumentException();
                    if (pICIniFile.m_value_set(sectors.sect_name4, str1_2, firstUnitTestCStr))
                        throw new ArgumentException();
                    if (pICIniFile.m_value_set(sectors.sect_name5, str1_3, firstUnitTestCStr))
                        throw new ArgumentException();
                    retCode++;
                    switch(retCode) {
                        case 1: {
                                if (!pICIniFile.m_load())
                                    throw new ArgumentException();
                                goto recheckICIniFileDataExists;
                            }
                        case 2: {
                                pICIniFile.m_clear();
                                if (!pICIniFile.m_save())
                                    throw new ArgumentException();
                                if (!pICIniFile.m_load())
                                    throw new ArgumentException();
                                goto recheckICIniFileDataExists;
                            }
                        default: break;
                    }

                    if (!pICIniFile.m_save())
                        throw new ArgumentException();
                    if (!pICIniFile.m_load())
                        throw new ArgumentException();

                    if (!pICIniFile.m_section_exist(sectors.sect_name1))
                        throw new ArgumentException();
                    if (!pICIniFile.m_section_exist(sectors.sect_name2))
                        throw new ArgumentException();
                    if (!pICIniFile.m_section_exist(sectors.sect_name3))
                        throw new ArgumentException();
                    if (pICIniFile.m_section_exist(sectors.sect_name4))
                        throw new ArgumentException();
                    if (pICIniFile.m_section_exist(sectors.sect_name5))
                        throw new ArgumentException();

                    if (!pICIniFile.m_section_delete(sectors.sect_name3))
                        throw new ArgumentException();
                    if (pICIniFile.m_section_exist(sectors.sect_name3))
                        throw new ArgumentException();
                    if (!pICIniFile.m_section_add(sectors.sect_name3))
                        throw new ArgumentException();
                    if (!pICIniFile.m_section_exist(sectors.sect_name3))
                        throw new ArgumentException();

                    if (!pICIniFile.m_key_exist(sectors.sect_name1, str1_0))
                        throw new ArgumentException();
                    if (!pICIniFile.m_key_exist(sectors.sect_name2, str1_1))
                        throw new ArgumentException();
                    if (pICIniFile.m_key_exist(sectors.sect_name3, str1_0))
                        throw new ArgumentException();
                    if (pICIniFile.m_key_exist(sectors.sect_name4, str1_2))
                        throw new ArgumentException();
                    if (pICIniFile.m_key_exist(sectors.sect_name5, str1_3))
                        throw new ArgumentException();

                    if (!pICIniFile.m_value_set(sectors.sect_name1, str1_0, firstUnitTestCStr))
                        throw new ArgumentException();
                    if (!pICIniFile.m_key_exist(sectors.sect_name1, str1_0))
                        throw new ArgumentException();

                    if (!pICIniFile.m_save())
                        throw new ArgumentException();

                    if (!pICIniFile.m_key_delete(sectors.sect_name1, str1_0))
                        throw new ArgumentException();
                    if (pICIniFile.m_key_exist(sectors.sect_name1, str1_0))
                        throw new ArgumentException();

                    if (!pICIniFile.m_load())
                        throw new ArgumentException();

                    if (!pICIniFile.m_key_exist(sectors.sect_name1, str1_0))
                        throw new ArgumentException();

                    retCode = 1;
                    string contentStr = null;
                    if (!pICIniFile.m_content(ref contentStr, ref retCode))
                        throw new ArgumentException();
                    if (!(contentStr != null && retCode != 0))
                        throw new ArgumentException();

                    if (iniFileDataStr.Length != retCode) //Does not required -1 after Length
                        throw new ArgumentException();

                    //retCode++; //Is not required.

                    if (!compareString(contentStr, iniFileDataStr, retCode))
                        throw new ArgumentException();

                    // Begin 0.5.3.4 Feature
                    StringBuilder section_name = new StringBuilder(Addon_API.ICIniFileClass.INIFILESECTIONMAX);
                    StringBuilder key_name = new StringBuilder(Addon_API.ICIniFileClass.INIFILEKEYMAX);
                    StringBuilder value_name = new StringBuilder(Addon_API.ICIniFileClass.INIFILEVALUEMAX);
                    uint ini_sec_count = pICIniFile.m_section_count();
                    if (ini_sec_count != 3)
                        throw new ArgumentException();

                    uint ini_key_count;
                    // Section 0 test
                    if (!pICIniFile.m_section_index(0, section_name))
                        throw new ArgumentException();
                    if (!compareString(sectors.sect_name1, section_name.ToString(), uint.MaxValue))
                        throw new ArgumentException();
                    ini_key_count = pICIniFile.m_key_count(section_name.ToString());
                    if (ini_key_count != 1)
                        throw new ArgumentException();

                    // Section 0 key 0 test
                    if (!pICIniFile.m_key_index(section_name.ToString(), 0, key_name, value_name))
                        throw new ArgumentException();
                    if (!compareString(str1_0, key_name.ToString(), uint.MaxValue))
                        throw new ArgumentException();
                    if (!compareString(firstUnitTestCStr, value_name.ToString(), uint.MaxValue))
                        throw new ArgumentException();

                    // Section 1 test
                    if (!pICIniFile.m_section_index(1, section_name))
                        throw new ArgumentException();
                    if (!compareString(sectors.sect_name2, section_name.ToString(), uint.MaxValue))
                        throw new ArgumentException();
                    ini_key_count = pICIniFile.m_key_count(section_name.ToString());
                    if (ini_key_count != 1)
                        throw new ArgumentException();

                    // Section 1 key 0 test
                    if (!pICIniFile.m_key_index(section_name.ToString(), 0, key_name, value_name))
                        throw new ArgumentException();
                    if (!compareString(str1_1, key_name.ToString(), uint.MaxValue))
                        throw new ArgumentException();
                    if (!compareString(firstUnitTestCStr, value_name.ToString(), uint.MaxValue))
                        throw new ArgumentException();

                    // Section 2 test
                    if (!pICIniFile.m_section_index(2, section_name))
                        throw new ArgumentException();
                    if (!compareString(sectors.sect_name3, section_name.ToString(), uint.MaxValue))
                        throw new ArgumentException();
                    ini_key_count = pICIniFile.m_key_count(section_name.ToString());
                    if (ini_key_count != 0)
                        throw new ArgumentException();

                    // End 0.5.3.4 Feature


                    if (!pICIniFile.m_delete_file(iniFileStr))
                        throw new ArgumentException();

                    pICIniFile.m_release();
                    MessageBox.Show("ICIniFile API has passed unit test.", "PASSED - ICIniFile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                    throw new ArgumentException();
            } catch (ArgumentException) {
                if (pICIniFile.isNotNull())
                    pICIniFile.m_release();
                MessageBox.Show("ICIniFile API has failed unit test.", "ERROR - ICIniFile", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Addon_API.EAO_RETURN.FAIL;
            }
#endif
            #endregion
            #region ICommand test section
#if EXT_ICOMMAND
            Addon_API.ICommand pICommand = Addon_API.Interface.getICommand(hash);
            try {
                if (pICommand.isNotNull()) {
                    //TODO: need to re-review this function internally.
                    if (pICommand.m_reload_level(hash))
                        throw new ArgumentException();

                    //This is needed in order to preserve function pointer address
                    eao_testExecutePtr = eao_testExecute;
                    GC.KeepAlive(eao_testExecutePtr);
                    eao_testExecuteOverridePtr = eao_testExecuteOverride;
                    GC.KeepAlive(eao_testExecuteOverridePtr);
                    eao_testExecuteOverride2Ptr = eao_testExecuteOverride2;
                    GC.KeepAlive(eao_testExecuteOverride2Ptr);

                    if (pICommand.m_delete(hash, eao_testExecutePtr, eaoTestExecuteStr))
                        throw new ArgumentException();
                    if (pICommand.m_alias_delete(eaoTestExecuteStr, eaoTestExecuteAliasStr))
                        throw new ArgumentException();

                    if (!pICommand.m_add(hash, eaoTestExecuteStr, eao_testExecutePtr, sectors.sect_name1, 1, 1, false, HEXT.modeAll))
                        throw new ArgumentException();
                    if (pICommand.m_add(hash, eaoTestExecuteStr, eao_testExecutePtr, sectors.sect_name1, 1, 1, false, HEXT.modeAll))
                        throw new ArgumentException();
                    if (!pICommand.m_delete(hash, eao_testExecutePtr, eaoTestExecuteStr))
                        throw new ArgumentException();
                    if (pICommand.m_delete(hash, eao_testExecutePtr, eaoTestExecuteStr))
                        throw new ArgumentException();
                    if (!pICommand.m_add(hash, eaoTestExecuteStr, eao_testExecutePtr, sectors.sect_name1, 1, 1, true, HEXT.modeAll))
                        throw new ArgumentException();
                    if (!pICommand.m_add(hash, eaoTestExecuteStr, eao_testExecuteOverridePtr, sectors.sect_name1, 1, 1, true, HEXT.modeAll))
                        throw new ArgumentException();
                    if (pICommand.m_add(hash, eaoTestExecuteStr, eao_testExecuteOverride2Ptr, sectors.sect_name1, 1, 1, true, HEXT.modeAll))
                        throw new ArgumentException();

                    if (!pICommand.m_alias_add(eaoTestExecuteStr, eaoTestExecuteAliasStr))
                        throw new ArgumentException();
                    if (pICommand.m_alias_add(eaoTestExecuteStr, eaoTestExecuteAliasStr))
                        throw new ArgumentException();
                    if (!pICommand.m_alias_delete(eaoTestExecuteStr, eaoTestExecuteAliasStr))
                        throw new ArgumentException();
                    if (pICommand.m_alias_delete(eaoTestExecuteStr, eaoTestExecuteAliasStr))
                        throw new ArgumentException();
                    if (!pICommand.m_alias_add(eaoTestExecuteStr, eaoTestExecuteAliasStr))
                        throw new ArgumentException();

                    if (!pICommand.m_reload_level(hash))
                        throw new ArgumentException();
                    if (!pICommand.m_load_from_file(hash, eaoLoadFileStr, plI, Addon_API.MSG_PROTOCOL.MP_RCON))
                        throw new ArgumentException();

                    // Proper remove command when done testing.
                    if (!pICommand.m_delete(hash, eao_testExecutePtr, eaoTestExecuteStr))
                        throw new ArgumentException();

                    MessageBox.Show("ICommand API has passed unit test.", "PASSED - ICommand", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                    throw new ArgumentException();
            } catch(ArgumentException) {
                MessageBox.Show("ICommand API has failed unit test.", "ERROR - ICommand", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Addon_API.EAO_RETURN.FAIL;

            }
#endif
            #endregion
            #region IObject test section
#if EXT_IOBJECT
            Addon_API.IObject pIObject = Addon_API.Interface.getIObject(hash);
            try {
                if (pIObject.isNotNull()) {
                    Addon_API.objTagGroupList gtag_list = new Addon_API.objTagGroupList();
                    if (!pIObject.m_get_lookup_group_tag_list(e_tag_group.TAG_WEAP, gtag_list))
                        throw new ArgumentException();
                    if (gtag_list.count == 0)
                        throw new ArgumentException();
                    Addon_API.hTagHeader_managed tag_header = gtag_list.list(0);
                    if (tag_header.isNull())
                        throw new ArgumentException();
                    if (tag_header.hTagHeader_n.group_tag != e_tag_group.TAG_WEAP)
                        throw new ArgumentException();
                    s_ident object_id = new s_ident(0);
                    s_ident parent_id = new s_ident();
                    Addon_API.objManaged move_object = new Addon_API.objManaged();
                    move_object.world.x = 1.0f;
                    move_object.world.y = 1.0f;
                    move_object.world.z = 1.0f;
                    if (!pIObject.m_create(tag_header.hTagHeader_n.ident, parent_id, 1000, ref object_id, ref move_object.world))
                        throw new ArgumentException();
                    s_object_managed created_object = pIObject.m_get_address(object_id);
                    if (created_object.getPtr().ptr == IntPtr.Zero)
                        throw new ArgumentException();

                    tag_header = pIObject.m_lookup_tag(created_object.s_object_n.ModelTag);
                    if (tag_header.isNull())
                        throw new ArgumentException();

                    if (created_object.s_object_n.World.x != 1.0f && created_object.s_object_n.World.y != 1.0f&& created_object.s_object_n.World.z != 1.0f)
                        throw new ArgumentException();
                    move_object.world.x = 2.0f;
                    move_object.world.y = 2.0f;
                    move_object.world.z = 2.0f;
                    pIObject.m_move(object_id, move_object);
                    created_object.refresh();
                    if (created_object.s_object_n.World.x != 2.0f && created_object.s_object_n.World.y != 2.0f&& created_object.s_object_n.World.z != 2.0f)
                        throw new ArgumentException();
                    move_object.world.x = 5.0f;
                    move_object.world.y = 5.0f;
                    move_object.world.z = 5.0f;
                    pIObject.m_move_and_reset(object_id, ref move_object.world);
                    created_object.refresh();
                    if (created_object.s_object_n.World.x != 5.0f && created_object.s_object_n.World.y != 5.0f&& created_object.s_object_n.World.z != 5.0f)
                        throw new ArgumentException();
                    pIObject.m_update(object_id);
                    if (!pIObject.m_destroy(object_id))
                        throw new ArgumentException();
                    MessageBox.Show("IObject API has passed unit test.", "PASSED - IObject", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                    throw new ArgumentException();
            } catch(ArgumentException) {
                MessageBox.Show("IObject API has failed unit test.", "ERROR - IObject", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Addon_API.EAO_RETURN.FAIL;
            }
#endif
            #endregion
            #region IPlayer test section
#if EXT_IPLAYER && !EXT_IADMIN
            Addon_API.IPlayer pIPlayer = Addon_API.Interface.getIPlayer(hash);
            try {
                if (pIPlayer.isNotNull()) {
                    StringBuilder testStr = new StringBuilder(64);
                    Addon_API.PlayerInfoList plList = new Addon_API.PlayerInfoList();
                    //Addon_API.PlayerInfo plINull = new Addon_API.PlayerInfo();

                    ushort totalPlayers = pIPlayer.m_get_str_to_player_list("*", ref plList, null);
                    if (totalPlayers == 0)
                        throw new ArgumentException();
                    Addon_API.PlayerInfo plITest = new Addon_API.PlayerInfo(), plITest2 = new Addon_API.PlayerInfo();
                    if (pIPlayer.m_get_m_index(2, ref plITest, true))
                        throw new ArgumentException();
                    if (pIPlayer.m_get_m_index(1, ref plITest, true))
                        throw new ArgumentException();
                    if (!pIPlayer.m_get_m_index(0, ref plITest, true))
                        throw new ArgumentException();
                    if (pIPlayer.m_get_id(200, ref plITest2))
                        throw new ArgumentException();
                    if (!pIPlayer.m_get_id((uint)plITest.plR.PlayerIndex, ref plITest2))
                        throw new ArgumentException();
                    if (!(plITest.cmS == plITest2.cmS && plITest.cplEx == plITest2.cplEx && plITest.cplS == plITest2.cplS && plITest.cplR == plITest2.cplR))
                        throw new ArgumentException();

                    s_biped_managed plBiped = pIObject.m_get_address(plITest.plS.CurrentBiped);
                    if (plBiped.getPtr().ptr == IntPtr.Zero)
                        throw new ArgumentException();
                    if (!pIPlayer.m_get_ident(plBiped.s_object_n.PlayerOwner, ref plITest2))
                        throw new ArgumentException();

                    if (pIPlayer.m_get_by_unique_id(600, ref plITest2))
                        throw new ArgumentException();
                    if (!pIPlayer.m_get_by_unique_id(plITest.mS.UniqueID, ref plITest2))
                        throw new ArgumentException();
                    if (!(plITest.cmS == plITest2.cmS && plITest.cplEx == plITest2.cplEx && plITest.cplS == plITest2.cplS && plITest.cplR == plITest2.cplR))
                        throw new ArgumentException();
                    retCode = pIPlayer.m_get_id_full_name(plITest.plR.PlayerName);
                    if (retCode == 0)
                        throw new ArgumentException();
                    if (!pIPlayer.m_get_full_name_id(retCode, testStr))
                        throw new ArgumentException();
                    if (testStr.ToString() != plITest.plR.PlayerName)
                        throw new ArgumentException();
                    testStr.Remove(0, testStr.Length);

                    retCode = pIPlayer.m_get_id_ip_address(plITest.plEx.IP_Addr);
                    if (retCode == 0)
                        throw new ArgumentException();
                    if (!pIPlayer.m_get_ip_address_id(retCode, testStr))
                        throw new ArgumentException();
                    if (testStr.ToString() != plITest.plEx.IP_Addr)
                        throw new ArgumentException();
                    testStr.Remove(0, testStr.Length);

                    retCode = pIPlayer.m_get_id_port(plITest.plEx.IP_Port);
                    if (retCode == 0)
                        throw new ArgumentException();
                    if (!pIPlayer.m_get_port_id(retCode, testStr))
                        throw new ArgumentException();
                    if (testStr.ToString() != plITest.plEx.IP_Port)
                        throw new ArgumentException();
                    testStr.Remove(0, testStr.Length);

                    if (pIPlayer.m_update(ref plINull))
                        throw new ArgumentException();

                    if (!pIPlayer.m_update(ref plITest))
                        throw new ArgumentException();

                    if (!pIPlayer.m_send_custom_message(Addon_API.MSG_FORMAT.MF_BLANK, Addon_API.MSG_PROTOCOL.MP_CHAT, ref plITest, "Simple blank prefix message for {0:s}", 1, plITest.plR.PlayerName))
                        throw new ArgumentException();
                    if (!pIPlayer.m_send_custom_message(Addon_API.MSG_FORMAT.MF_SERVER, Addon_API.MSG_PROTOCOL.MP_CHAT, ref plITest, "Simple server prefix message for {0:s}", 1, plITest.plR.PlayerName))
                        throw new ArgumentException();

                    if (!pIPlayer.m_send_custom_message_broadcast(Addon_API.MSG_FORMAT.MF_BLANK, "Simple blank prefix message for {0:s}", 0))
                        throw new ArgumentException();
                    if (!pIPlayer.m_send_custom_message_broadcast(Addon_API.MSG_FORMAT.MF_SERVER, "Simple server prefix message for {0:s}", 0))
                        throw new ArgumentException();

                    //m_apply_camo test only required biped data to verify data is set to camoflauge.
                    plBiped.refresh();
                    if ((plBiped.s_object_n.isVisible & 0x10) != 0)
                        throw new ArgumentException();
                    pIPlayer.m_apply_camo(ref plITest, 10);
                    plBiped.refresh();
                    if ((plBiped.s_object_n.isVisible & 0x10) == 0)
                        throw new ArgumentException();

                    e_color_team_index oldTeam = plITest.plR.Team;
                    pIPlayer.m_change_team(ref plITest, (e_color_team_index)Convert.ToByte((oldTeam == e_color_team_index.TEAM_RED)), true);
                    if (plITest.plR.Team == oldTeam)
                        throw new ArgumentException();

                    tm gmtm = new tm();
                    System.DateTime time = DateTime.UtcNow;
                    gmtm.tm_isdst = Convert.ToInt32(time.IsDaylightSavingTime());
                    gmtm.tm_yday = time.DayOfYear;
                    gmtm.tm_wday = (int)time.DayOfWeek;
                    gmtm.tm_year = time.Year-1900;
                    gmtm.tm_mon = time.Month - 1;
                    gmtm.tm_mday = time.Day;
                    gmtm.tm_hour = time.Hour;
                    gmtm.tm_min = time.Minute + 5;
                    gmtm.tm_sec = time.Second;
                    Addon_API.PlayerExtended plEx = plITest.plEx;
                    if (pIPlayer.m_ban_player(ref plEx, ref gmtm) == 0) 
                        throw new ArgumentException();
                    uint banID, banID2;
                    //Test CD hash key (un)ban verification
                    if ((banID = pIPlayer.m_ban_CD_key_get_id(plITest.plEx.CDHashW)) == 0)
                        throw new ArgumentException();
                    if (!pIPlayer.m_unban_id(banID))
                        throw new ArgumentException();
                    //TODO: Does not validate if CD hash is valid first before ban
                    if (pIPlayer.m_ban_CD_key(plITest.plEx.CDHashW, ref gmtm)!=Addon_API.e_boolean.TRUE)
                        throw new ArgumentException();
                    if ((banID2 = pIPlayer.m_ban_CD_key_get_id(plITest.plEx.CDHashW)) == 0)
                        throw new ArgumentException();
                    if (banID != banID2)
                        throw new ArgumentException();
                    //Test IP Address (un)ban verification
                    if ((banID = pIPlayer.m_ban_ip_get_id(plITest.plEx.IP_Addr)) == 0)
                        throw new ArgumentException();
                    if (!pIPlayer.m_unban_id(banID))
                        throw new ArgumentException();
                    //TODO: Does not validate if IP Address is valid first before ban
                    if (pIPlayer.m_ban_ip(plITest.plEx.IP_Addr, ref gmtm)!=Addon_API.e_boolean.TRUE)
                        throw new ArgumentException();
                    if ((banID2 = pIPlayer.m_ban_ip_get_id(plITest.plEx.IP_Addr)) == 0)
                        throw new ArgumentException();
                    if (banID != banID2)
                        throw new ArgumentException();

                    in_addr ipAddr = new in_addr();
                    ushort port = 0;
                    s_machine_slot mS = plITest.mS;
                    if (!pIPlayer.m_get_ip(ref mS, ref ipAddr))
                        throw new ArgumentException();
                    if (!pIPlayer.m_get_port(ref mS, ref port))
                        throw new ArgumentException();
                    if (!pIPlayer.m_get_CD_hash(ref mS, testStr))
                        throw new ArgumentException();

                    //Uncomment this part if need to verify function return correctly with/out an admin player.
                    //if (!pIPlayer.m_is_admin((byte)mS.machineIndex))
                        //throw new ArgumentException();

                    MessageBox.Show("IPlayer API has passed unit test.", "PASSED - IPlayer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                    throw new ArgumentException();
            } catch (ArgumentException) {
                MessageBox.Show("IPlayer API has failed unit test.", "ERROR - IPlayer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Addon_API.EAO_RETURN.FAIL;
            }
#endif
            #endregion
            #region IAdmin test section
#if EXT_IADMIN
#if !EXT_IPLAYER
#error EXT_IPLAYER is required for testing EXT_IADMIN
#endif
            Addon_API.IPlayer pIPlayer = Addon_API.Interface.getIPlayer(hash);
            Addon_API.IAdmin pIAdmin = Addon_API.Interface.getIAdmin(hash);
            try {
                if (pIAdmin.isNotNull() && pIPlayer.isNotNull()) {
                    Addon_API.PlayerInfo plIMockup = new Addon_API.PlayerInfo();
                    if (!pIPlayer.m_get_m_index(0, ref plIMockup, true))
                    throw new ArgumentException();

                    if (pIAdmin.m_is_username_exist(username) != Addon_API.e_boolean.FALSE)
                        throw new ArgumentException();
                    if (pIAdmin.m_delete(username) != Addon_API.e_boolean.FALSE)
                        throw new ArgumentException();
                    Addon_API.ArgContainer arg = new Addon_API.ArgContainer();
                    Addon_API.CmdFunc func = null;
                    short tmpLvl = plIMockup.plEx.adminLvl;
                    Addon_API.PlayerExtended tmpPlEx = plIMockup.plEx;
                    tmpPlEx.adminLvl = 0;
                    plIMockup.plEx = tmpPlEx;
                    if (pIAdmin.m_is_authorized(ref plIMockup, cmdEaoLoad, ref arg.vars, ref func) != Addon_API.CMD_AUTH.DENIED)
                        throw new ArgumentException();
                    tmpPlEx.adminLvl = 9999;
                    plIMockup.plEx = tmpPlEx;
                    if (pIAdmin.m_is_authorized(ref plIMockup, cmdEaoLoad, ref arg.vars, ref func) != Addon_API.CMD_AUTH.AUTHORIZED)
                        throw new ArgumentException();
                    tmpPlEx.adminLvl = tmpLvl;

                    if (pIAdmin.m_add(tmpPlEx.CDHashW, tmpPlEx.IP_Addr, "0", username, username, 9999, false, false) != Addon_API.e_boolean.TRUE)
                        throw new ArgumentException();
                    if (pIAdmin.m_add(tmpPlEx.CDHashW, tmpPlEx.IP_Addr, "0", username, username, 9999, false, false) != Addon_API.e_boolean.FALSE)
                        throw new ArgumentException();
                    if (pIAdmin.m_is_username_exist(username) != Addon_API.e_boolean.TRUE)
                        throw new ArgumentException();
                    if (pIAdmin.m_is_authorized(ref plIMockup, cmdEaoLoad, ref arg.vars, ref func) != Addon_API.CMD_AUTH.AUTHORIZED)
                        throw new ArgumentException();
                    if (pIAdmin.m_login(ref plIMockup, Addon_API.MSG_PROTOCOL.MP_CHAT, usernamebad, username) != Addon_API.LOGIN_VALIDATION.FAIL)
                        throw new ArgumentException();
                    if (pIAdmin.m_is_authorized(ref plIMockup, cmdEaoLoad, ref arg.vars, ref func) != Addon_API.CMD_AUTH.DENIED)
                        throw new ArgumentException();
                    if (pIAdmin.m_login(ref plIMockup, Addon_API.MSG_PROTOCOL.MP_CHAT, username, username) != Addon_API.LOGIN_VALIDATION.OK)
                        throw new ArgumentException();
                    if (pIAdmin.m_is_authorized(ref plIMockup, cmdEaoLoad, ref arg.vars, ref func) != Addon_API.CMD_AUTH.AUTHORIZED)
                        throw new ArgumentException();

                    if (pIAdmin.m_delete(username) != Addon_API.e_boolean.TRUE)
                        throw new ArgumentException();
                    if (pIAdmin.m_delete(username) != Addon_API.e_boolean.FALSE)
                        throw new ArgumentException();
                    MessageBox.Show("IAdmin API has passed unit test.", "PASSED - IAdmin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                    throw new ArgumentException();
            } catch (ArgumentException) {
                MessageBox.Show("IAdmin API has failed unit test.", "ERROR - IAdmin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Addon_API.EAO_RETURN.FAIL;
            }
#endif
            #endregion
            #region IHaloEngine test section
#if EXT_IHALOENGINE
            Addon_API.IHaloEngine pIHaloEngine = Addon_API.Interface.getIHaloEngine(hash);
            try {
                if (pIHaloEngine.isNotNull()) {
                    s_server_header_managed serverHeader = pIHaloEngine.serverHeader;
                    /*TODO: Need find better test for serverHeader.
                    if (serverHeader.data.totalPlayers !=1)
                        throw new ArgumentException();
                    */
                    s_player_reserved_slot_managed playerReserved = pIHaloEngine.playerReserved;
                    if (!(playerReserved.data.MachineIndex == 0 && playerReserved.data.PlayerIndex == 0))
                        throw new ArgumentException();

                    if (pIHaloEngine.isDedi && pIHaloEngine.haloGameVersion == Addon_API.HALO_VERSION.CE) {
                        if (pIHaloEngine.machineHeaderSize != 0xEC)
                            throw new ArgumentException();
                    } else {
                        if (pIHaloEngine.machineHeaderSize != 0x60)
                            throw new ArgumentException();
                    }
                    s_machine_slot_managed mSIndex = pIHaloEngine.machineHeader;
                    if (!(mSIndex.data.machineIndex == 0 && mSIndex.data.isAvailable == 0 && mSIndex.data.data1 !=IntPtr.Zero && mSIndex.data.Unknown9 == 0x0007))
                        throw new ArgumentException();
                    Addon_API.PlayerInfo pl1 = new Addon_API.PlayerInfo();
                    pl1.cmS = mSIndex.getPtr().ptr;
                    mSIndex++;
                    if (!(mSIndex.data.machineIndex == -1 && mSIndex.data.data1 == IntPtr.Zero && mSIndex.data.Unknown9 == 0x0000))
                        throw new ArgumentException();
                    mSIndex--;
                    s_map_header_managed mapHeader = pIHaloEngine.mapCurrent;
                    if (mapHeader.data.head != 0x68656164) //'head'
                        throw new ArgumentException();
                    switch (pIHaloEngine.haloGameVersion) {
                        case Addon_API.HALO_VERSION.TRIAL: {
                            if (mapHeader.data.haloVersion != 0x00000006)
                                throw new ArgumentException();
                            break;
                        }
                        case Addon_API.HALO_VERSION.CE: {
                            if (mapHeader.data.haloVersion != 0x00000261)
                                throw new ArgumentException();
                            break;
                        }
                        case Addon_API.HALO_VERSION.PC: {
                                if (mapHeader.data.haloVersion != 0x00000007)
                                    throw new ArgumentException();
                                break;
                        }
                        case Addon_API.HALO_VERSION.UNKNOWN:
                        default: {
                            throw new ArgumentException();
                        }
                    }
                    if (pIHaloEngine.mapTimeLimitPermament.value != UInt32.MaxValue)
                        if (pIHaloEngine.mapTimeLimitLive.value != pIHaloEngine.mapTimeLimitPermament.value)
                        throw new ArgumentException();
                    s_map_status_managed mapStatus = pIHaloEngine.mapStatus;
                    if (mapStatus.data.upTime != pIHaloEngine.mapUpTimeLive.value)
                        throw new ArgumentException();
                    /*
                     * m_dispatch_rcon
                     */
                    rconDataManaged rcon = new rconDataManaged(rconTestStr);
                    pIHaloEngine.m_dispatch_rcon(ref rcon.data, ref pl1);
                    /*
                     * m_dispatch_player
                     */
                    chatDataManaged d = new chatDataManaged(playerChatTest, 0, chatType.TEAM);
                    // Gotta pass a pointer to the chatData struct
                    IntPtr d_ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(chatData)));
                    Marshal.StructureToPtr(d.data, d_ptr, true);
                    // Build the chat packet
                    byte[] packetBuffer = new byte[4092 + 2 * playerChatTest.Length];
                    GC.KeepAlive(packetBuffer);
                    retCode = pIHaloEngine.m_build_packet(packetBuffer, 0, 0x0F, 0, ref d_ptr, 0, 1, 0);
                    pIHaloEngine.m_add_packet_to_player_queue((uint)mSIndex.data.machineIndex, packetBuffer, retCode, 1, 1, 0, 1, 3);
                    //
                    pIHaloEngine.m_dispatch_player(ref d.data, (uint)Marshal.SizeOf(typeof(chatData)), ref pl1);
                    /*
                     * m_dispatch_global
                     */
                    d = new chatDataManaged(globalChatTest, 0, chatType.GLOBAL);
                    // Gotta pass a pointer to the chatData struct
                    Marshal.StructureToPtr(d.data, d_ptr, true);
                    //GC.KeepAlive(playerChatTest);
                    // Build the chat packet
                    packetBuffer = new byte[4092 + 2 * globalChatTest.Length];
                    GC.KeepAlive(packetBuffer);
                    retCode = pIHaloEngine.m_build_packet(packetBuffer, 0, 0x0F, 0, ref d_ptr, 0, 1, 0);
                    pIHaloEngine.m_add_packet_to_global_queue(packetBuffer, retCode, 1, 1, 0, 1, 3);
                    //
                    pIHaloEngine.m_dispatch_global(ref d.data, (uint)Marshal.SizeOf(typeof(chatData)));
                    // Since C# is a managed code, we need to free up allocated space.
                    Marshal.FreeHGlobal(d_ptr);
                    //
                    if (pIHaloEngine.isDedi) {
                        if (!pIHaloEngine.m_map_next())
                            throw new ArgumentException();
                        if (!pIHaloEngine.m_set_idling())
                            throw new ArgumentException();
                    }
                    if (!pIHaloEngine.m_send_reject_code(pIHaloEngine.machineHeader, Addon_API.REJECT_CODE.VIDEO_TEST))
                        throw new ArgumentException();
                    if (!pIHaloEngine.m_exec_command("sv_maplist"))
                        throw new ArgumentException();
                    pIHaloEngine.m_set_server_password(password);
                    pIHaloEngine.m_get_server_password(passwordWGet);
                    if (password != passwordWGet.ToString())
                        throw new ArgumentException();
                    pIHaloEngine.m_set_rcon_password(password);
                    pIHaloEngine.m_get_rcon_password(passwordAGet);
                    if (password != passwordAGet.ToString())
                        throw new ArgumentException();

                    //Addon test section
                    /*TODO: Both functions will not work in middle of load process.
                    Addon_API.addon_info eaoInfo = new Addon_API.addon_info();
                    if (!pIHaloEngine.m_ext_add_on_get_info_by_index(0, ref eaoInfo))
                        throw new ArgumentException();
                    eaoInfo.author.Remove(0, eaoInfo.author.Length);
                    eaoInfo.config_folder.Remove(0, eaoInfo.config_folder.Length);
                    if (!pIHaloEngine.m_ext_add_on_get_info_by_name(eaoInfo.name, ref eaoInfo))
                        throw new ArgumentException();
                    */
                    //TODO: This function cannot be tested otherwise it will go in a loop plus is not fully implemented yet.
                    //if (!pIHaloEngine.m_ext_add_on_reload(EXTPluginInfo.name))
                    //    THROW(8);
                    MessageBox.Show("IHaloEngine API has passed unit test.", "PASSED - IHaloEngine", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                    throw new ArgumentException();
            } catch (ArgumentException) {
                MessageBox.Show("IHaloEngine API has failed unit test.", "ERROR - IHaloEngine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Addon_API.EAO_RETURN.FAIL;
            }
#endif
            #endregion
            #region I__ test section
#if TEMPLATE_COPY
            Addon_API.  = Addon_API.Interface.(hash);
            try {
                if (.isNotNull()) {

                    MessageBox.Show(" API has passed unit test.", "PASSED - ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                    throw new ArgumentException();
            } catch (ArgumentException) {
                MessageBox.Show(" API has failed unit test.", "ERROR - ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Addon_API.EAO_RETURN.FAIL;
            }
#endif
            #endregion
            #region ITimer test section
#if EXT_ITIMER
            pITimer = Addon_API.Interface.getITimer(hash);
            try {
                if (pITimer.isNotNull()) {

                    TimerID[0] = pITimer.m_add(hash, null, 0); //1/30 second
                    if (TimerID[0] == 0)
                        throw new ArgumentException();
                    TimerID[1] = pITimer.m_add(hash, null, 60); //2 seconds
                    if (TimerID[1] == 0)
                        throw new ArgumentException();
                    pITimer.m_delete(hash, TimerID[1]);
                } else
                    throw new ArgumentException();
            } catch(ArgumentException) {
                MessageBox.Show("ITimer API has failed unit test.", "ERROR - ITimer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Addon_API.EAO_RETURN.FAIL;
            }
#endif
            #endregion
            GC.Collect();
            return Addon_API.EAO_RETURN.OVERRIDE;
        }

        [DllExport("EXTOnEAOUnload", CallingConvention = CallingConvention.Cdecl)]
        public static void EXTOnEAOUnload() {
        }
#if EXT_HKTIMER
        [DllExport("EXTOnTimerExecute", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static bool EXTOnTimerExecute(UInt32 id, UInt32 count) {
            try { 
                if (TimerID[0] == id) {
                    if (TimerTickStart == 0) {
                        TimerTickStart = (uint)Environment.TickCount;
                        TimerID[0] = pITimer.m_add(hash, null, 150); //5 seconds
                        if (TimerID[0] == 0)
                            throw new ArgumentException();
                        TimerID[2] = pITimer.m_add(hash, null, 30); //1 second
                        if (TimerID[2] == 0)
                            throw new ArgumentException();
                    } else {
                        TimerTickSys[0] = (uint)Environment.TickCount;
                        uint tmpTimerCheck = TimerTickSys[0] - TimerTickStart;
                        if (!(4500 < tmpTimerCheck && tmpTimerCheck < 5033))
                            throw new ArgumentException();
                        if (TimerTickSys[1] != 0)
                            throw new ArgumentException();
                        tmpTimerCheck = TimerTickSys[2] - TimerTickStart;
                        if (!(500 < tmpTimerCheck && tmpTimerCheck < 1033))
                            throw new ArgumentException();
                        tmpTimerCheck = TimerTickSys[3] - TimerTickStart;
                        if (!(2500 < tmpTimerCheck && tmpTimerCheck < 3033))
                            throw new ArgumentException();
                        MessageBox.Show("ITimer API has passed unit test.", "PASSED - ITimer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } else if (TimerID[1] == id) {
                    TimerTickSys[1] = (uint)Environment.TickCount;
                } else if (TimerID[2] == id) {
                    TimerTickSys[2] = (uint)Environment.TickCount;
                    TimerID[3] = pITimer.m_add(hash, null, 60); //2 seconds
                    if (TimerID[3] == 0)
                        throw new ArgumentException();
                } else if (TimerID[3] == id) {
                    TimerTickSys[3] = (uint)Environment.TickCount;
                } else {
                    throw new ArgumentException();
                }
            } catch (ArgumentException) {
                MessageBox.Show("ITimer API has failed unit test.", "ERROR - ITimer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false; //Tell H-Ext not to repeat timer.
        }
        [DllExport("EXTOnTimerCancel", CallingConvention = CallingConvention.Cdecl)]
        public static void EXTOnTimerCancel(UInt32 id) {
            if (TimerID[0] == id) {
            } else if (TimerID[1] == id) {
            } else if (TimerID[2] == id) {
            } else if (TimerID[3] == id) {
            } else {
                MessageBox.Show("ITimer API has failed unit test.", "ERROR - ITimer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
#endif
        private static bool compareString(string str1, string str2, uint length) {
            if (length == uint.MaxValue) {
                if (str1.Length != str2.Length)
                    return false;
                length = 0;
                while (str1.Length < length) {
                    if (str1[(int)length] != str2[(int)length])
                        return false;
                    length++;
                }
            } else {
                do {
                    length--;
                    if (str1[(int)length] != str2[(int)length])
                        return false;
                } while (length != 0);
            }
            return true;
        }
    }
}


