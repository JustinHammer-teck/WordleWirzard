//
//
// //--------------------------------------------------------------------------------------+
// //
// //    $Source: Words.cs $
// // 
// //    $Copyright: (c) 2022 Mike Palmer. All rights reserved. $
// //
// //---------------------------------------------------------------------------------------+
//
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// namespace WordGuess.Web.Entities;
//
//     public class Words
//     {
//         public struct WordleWords
//         {
//             public int wordIndex;
//             public string word;
//             public string firstLetter;
//             public string secondLetter;
//             public string thirdLetter;
//             public string forthLetter;
//             public string fifthLetter;
//         }
//
//
//         private List<WordleWords> allWords = new List<WordleWords>();
//         private int count = 0;
//         private int wordIndex = 0;
//         private int aIndex = 0;  // Index into the allWords list
//         private int bIndex = 0;  // Index into the allWords list
//         private int cIndex = 0;  // Index into the allWords list
//         private int dIndex = 0;  // Index into the allWords list
//         private int eIndex = 0;  // Index into the allWords list
//         private int fIndex = 0;  // Index into the allWords list
//         private int gIndex = 0;  // Index into the allWords list
//         private int hIndex = 0;  // Index into the allWords list
//         private int iIndex = 0;  // Index into the allWords list
//         private int jIndex = 0;  // Index into the allWords list
//         private int kIndex = 0;  // Index into the allWords list
//         private int lIndex = 0;  // Index into the allWords list
//         private int mIndex = 0;  // Index into the allWords list
//         private int nIndex = 0;  // Index into the allWords list
//         private int oIndex = 0;  // Index into the allWords list
//         private int pIndex = 0;  // Index into the allWords list
//         private int qIndex = 0;  // Index into the allWords list
//         private int rIndex = 0;  // Index into the allWords list
//         private int sIndex = 0;  // Index into the allWords list
//         private int tIndex = 0;  // Index into the allWords list
//         private int uIndex = 0;  // Index into the allWords list
//         private int vIndex = 0;  // Index into the allWords list
//         private int wIndex = 0;  // Index into the allWords list
//         private int xIndex = 0;  // Index into the allWords list - No 5 letter words starting with X
//         private int yIndex = 0;  // Index into the allWords list
//         private int zIndex = 0;  // Index into the allWords list
//
//
//         /// <summary>
//         /// Constructor
//         /// </summary>
//         public Words()
//         {
//             PopulateWordList();
//         }
//
//
//         /// <summary>
//         /// Fills the list of available words
//         /// </summary>
//         /// <param name="lv">ListView object to fill in</param>
//         /// <param name="invalidLetters">string of invalid letters</param>
//         /// <param name="correctLetters">WordleWords of correct letters in correct spot</param>
//         /// <param name="goodLetters">WordleWords array of correct letters in incorrect spot</param>
//         public void PopulateListWithValidWords(ListView lv, string invalidLetters, WordleWords correctLetters, WordleWords[] goodLetters)
//         {
//             try
//             {
//                 bool skip = false;
//
//                 if (lv == null)
//                 {
//                     return;
//                 }
//
//                 if (lv.Items.Count > 0)
//                 {
//                     lv.Items.Clear();
//                 }
//
//                 count = allWords.Count;
//
//                 if (String.IsNullOrEmpty(correctLetters.firstLetter) == false)
//                 {
//                     if (String.Compare(correctLetters.firstLetter, "A") == 0)
//                     {
//                         wordIndex = aIndex;
//                         count = bIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "B") == 0)
//                     {
//                         wordIndex = bIndex;
//                         count = cIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "C") == 0)
//                     {
//                         wordIndex = cIndex;
//                         count = dIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "D") == 0)
//                     {
//                         wordIndex = dIndex;
//                         count = eIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "E") == 0)
//                     {
//                         wordIndex = eIndex;
//                         count = fIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "F") == 0)
//                     {
//                         wordIndex = fIndex;
//                         count = gIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "G") == 0)
//                     {
//                         wordIndex = gIndex;
//                         count = hIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "H") == 0)
//                     {
//                         wordIndex = hIndex;
//                         count = iIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "I") == 0)
//                     {
//                         wordIndex = iIndex;
//                         count = jIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "J") == 0)
//                     {
//                         wordIndex = jIndex;
//                         count = kIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "K") == 0)
//                     {
//                         wordIndex = kIndex;
//                         count = lIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "L") == 0)
//                     {
//                         wordIndex = lIndex;
//                         count = mIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "M") == 0)
//                     {
//                         wordIndex = mIndex;
//                         count = nIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "N") == 0)
//                     {
//                         wordIndex = nIndex;
//                         count = oIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "O") == 0)
//                     {
//                         wordIndex = oIndex;
//                         count = pIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "P") == 0)
//                     {
//                         wordIndex = pIndex;
//                         count = qIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "Q") == 0)
//                     {
//                         wordIndex = qIndex;
//                         count = rIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "R") == 0)
//                     {
//                         wordIndex = rIndex;
//                         count = sIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "S") == 0)
//                     {
//                         wordIndex = sIndex;
//                         count = tIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "T") == 0)
//                     {
//                         wordIndex = tIndex;
//                         count = uIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "U") == 0)
//                     {
//                         wordIndex = uIndex;
//                         count = vIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "V") == 0)
//                     {
//                         wordIndex = vIndex;
//                         count = wIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "W") == 0)
//                     {
//                         wordIndex = wIndex;
//                         count = tIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "X") == 0)
//                     {
//                         // There are no five letter words that beegin with X
//                         wordIndex = yIndex;
//                         count = yIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "Y") == 0)
//                     {
//                         wordIndex = yIndex;
//                         count = zIndex;
//                     }
//                     else if (String.Compare(correctLetters.firstLetter, "Z") == 0)
//                     {
//                         wordIndex = zIndex;
//                         count = allWords.Count;
//                     }
//                 }
//
//                 for (int index = wordIndex; index < count; index++)
//                 {
//                     ListViewItem lvItem = null;
//                     WordleWords word = allWords[index];
//
//                     skip = false;
//
//                     // Eliminate words base on Correct letters first
//                     if (String.IsNullOrEmpty(correctLetters.firstLetter) == false)
//                     {
//                         if (String.Compare(word.word.Substring(0, 1).ToUpper(), correctLetters.firstLetter.ToUpper()) != 0)
//                         {
//                             skip = true;
//
//                             continue;
//                         }
//                     }
//
//                     if (skip == false)
//                     {
//                         if (String.IsNullOrEmpty(correctLetters.secondLetter) == false)
//                         {
//                             if (String.Compare(word.word.Substring(1, 1).ToUpper(), correctLetters.secondLetter.ToUpper()) != 0)
//                             {
//                                 skip = true;
//
//                                 continue;
//                             }
//                         }
//                     }
//
//                     if (skip == false)
//                     {
//                         if (String.IsNullOrEmpty(correctLetters.thirdLetter) == false)
//                         {
//                             if (String.Compare(word.word.Substring(2, 1).ToUpper(), correctLetters.thirdLetter.ToUpper()) != 0)
//                             {
//                                 skip = true;
//
//                                 continue;
//                             }
//                         }
//                     }
//
//                     if (skip == false)
//                     {
//                         if (String.IsNullOrEmpty(correctLetters.forthLetter) == false)
//                         {
//                             if (String.Compare(word.word.Substring(3, 1).ToUpper(), correctLetters.forthLetter.ToUpper()) != 0)
//                             {
//                                 skip = true;
//
//                                 continue;
//                             }
//                         }
//                     }
//
//                     if (skip == false)
//                     {
//                         if (String.IsNullOrEmpty(correctLetters.fifthLetter) == false)
//                         {
//                             if (String.Compare(word.word.Substring(4, 1).ToUpper(), correctLetters.fifthLetter.ToUpper()) != 0)
//                             {
//                                 skip = true;
//
//                                 continue;
//                             }
//                         }
//                     }
//                     // End - Eliminate words base on Correct letters first
//
//
//                     // Eliminate words base on Invalid letters next
//                     for (int invalidIndex = 0; invalidIndex < invalidLetters.Length; invalidIndex++)
//                     {
//                         int indexOf = -1;
//
//                         indexOf = word.word.ToUpper().IndexOf(invalidLetters.Substring(invalidIndex, 1));
//
//                         if (indexOf >= 0)
//                         {
//                             skip = true;
//
//                             break;
//                         }
//                     }
//                     // End - Eliminate words base on Invalid letters next
//
//                     if (skip == true)
//                     {
//                         continue;
//                     }
//
//
//                     // Eliminate words base on Good letters in the wrong spot last
//                     for (int goodCntr = 0; goodCntr < 6; goodCntr++)
//                     {
//                         WordleWords goodChars = goodLetters[goodCntr];
//                         int charLocation = -1;
//
//                         // Check to see if the Good Letter is in the current word
//                         if (skip == false)
//                         {
//                             if (String.IsNullOrEmpty(goodChars.firstLetter) == false)
//                             {
//                                 charLocation = word.word.IndexOf(goodChars.firstLetter);
//
//                                 if ((charLocation < 0) || (charLocation == 0))
//                                 {
//                                     skip = true;
//
//                                     break;
//                                 }
//                             }
//                         }
//
//                         if (skip == false)
//                         {
//                             if (String.IsNullOrEmpty(goodChars.secondLetter) == false)
//                             {
//                                 // Check to see if the Good Letter is in the current word
//                                 charLocation = word.word.IndexOf(goodChars.secondLetter);
//
//                                 if ((charLocation < 0) || (charLocation == 1))
//                                 {
//                                     skip = true;
//
//                                     break;
//                                 }
//                             }
//                         }
//
//                         if (skip == false)
//                         {
//                             // Check to see if the Good Letter is in the current word
//                             if (String.IsNullOrEmpty(goodChars.thirdLetter) == false)
//                             {
//                                 charLocation = word.word.IndexOf(goodChars.thirdLetter);
//
//                                 if ((charLocation < 0) || (charLocation == 2))
//                                 {
//                                     skip = true;
//
//                                     break;
//                                 }
//                             }
//                         }
//
//                         if (skip == false)
//                         {
//                             if (String.IsNullOrEmpty(goodChars.forthLetter) == false)
//                             {
//                                 // Check to see if the Good Letter is in the current word
//                                 charLocation = word.word.IndexOf(goodChars.forthLetter);
//
//                                 if ((charLocation < 0) || (charLocation == 3))
//                                 {
//                                     skip = true;
//
//                                     break;
//                                 }
//                             }
//                         }
//
//                         if (skip == false)
//                         {
//                             if (String.IsNullOrEmpty(goodChars.fifthLetter) == false)
//                             {
//                                 // Check to see if the Good Letter is in the current word
//                                 charLocation = word.word.IndexOf(goodChars.fifthLetter);
//
//                                 if ((charLocation < 0) || (charLocation == 4))
//                                 {
//                                     skip = true;
//
//                                     break;
//                                 }
//                             }
//                         }
//                     }
//
//                     if (skip == true)
//                     {
//                         continue;
//                     }
//
//                     if (skip == false)
//                     {
//                         lvItem = new ListViewItem(word.word);
//                         lv.Items.Add(lvItem);
//                     }
//                 }
//                 // End - Eliminate words base on Good letters in the wrong spot last
//             }
//             catch
//             {
//                 ;
//             }
//         }
//
//
//         /// <summary>
//         /// Populates the allWords list
//         /// </summary>
//         private void PopulateWordList()
//         { 
//             int index = 0;
//
//             aIndex = index;
//
//             AddWord("ABACK", index++);
//             AddWord("ABASE", index++);
//             AddWord("ABATE", index++);
//             AddWord("ABBEY", index++);
//             AddWord("ABBOT", index++);
//             AddWord("ABHOR", index++);
//             AddWord("ABIDE", index++);
//             AddWord("ABLED", index++);
//             AddWord("ABODE", index++);
//             AddWord("ABORT", index++);
//             AddWord("ABOUT", index++);
//             AddWord("ABOVE", index++);
//             AddWord("ABUSE", index++);
//             AddWord("ABYSS", index++);
//             AddWord("ACORN", index++);
//             AddWord("ACRID", index++);
//             AddWord("ACTOR", index++);
//             AddWord("ACUTE", index++);
//             AddWord("ADAGE", index++);
//             AddWord("ADAPT", index++);
//             AddWord("ADEPT", index++);
//             AddWord("ADMIN", index++);
//             AddWord("ADMIT", index++);
//             AddWord("ADOBE", index++);
//             AddWord("ADOPT", index++);
//             AddWord("ADORE", index++);
//             AddWord("ADORN", index++);
//             AddWord("ADULT", index++);
//             AddWord("AFFIX", index++);
//             AddWord("AFIRE", index++);
//             AddWord("AFOOT", index++);
//             AddWord("AFOUL", index++);
//             AddWord("AFTER", index++);
//             AddWord("AGAIN", index++);
//             AddWord("AGAPE", index++);
//             AddWord("AGATE", index++);
//             AddWord("AGENT", index++);
//             AddWord("AGILE", index++);
//             AddWord("AGING", index++);
//             AddWord("AGLOW", index++);
//             AddWord("AGONY", index++);
//             AddWord("AGREE", index++);
//             AddWord("AHEAD", index++);
//             AddWord("AIDER", index++);
//             AddWord("AISLE", index++);
//             AddWord("ALARM", index++);
//             AddWord("ALBUM", index++);
//             AddWord("ALERT", index++);
//             AddWord("ALGAE", index++);
//             AddWord("ALIBI", index++);
//             AddWord("ALIEN", index++);
//             AddWord("ALIGN", index++);
//             AddWord("ALIKE", index++);
//             AddWord("ALIVE", index++);
//             AddWord("ALLAY", index++);
//             AddWord("ALLEY", index++);
//             AddWord("ALLOT", index++);
//             AddWord("ALLOW", index++);
//             AddWord("ALLOY", index++);
//             AddWord("ALOFT", index++);
//             AddWord("ALONE", index++);
//             AddWord("ALONG", index++);
//             AddWord("ALOOF", index++);
//             AddWord("ALOUD", index++);
//             AddWord("ALPHA", index++);
//             AddWord("ALTAR", index++);
//             AddWord("ALTER", index++);
//             AddWord("AMASS", index++);
//             AddWord("AMAZE", index++);
//             AddWord("AMBER", index++);
//             AddWord("AMBLE", index++);
//             AddWord("AMEND", index++);
//             AddWord("AMISS", index++);
//             AddWord("AMITY", index++);
//             AddWord("AMONG", index++);
//             AddWord("AMPLE", index++);
//             AddWord("AMPLY", index++);
//             AddWord("AMUSE", index++);
//             AddWord("ANGEL", index++);
//             AddWord("ANGER", index++);
//             AddWord("ANGLE", index++);
//             AddWord("ANGRY", index++);
//             AddWord("ANGST", index++);
//             AddWord("ANIME", index++);
//             AddWord("ANKLE", index++);
//             AddWord("ANNEX", index++);
//             AddWord("ANNOY", index++);
//             AddWord("ANNUL", index++);
//             AddWord("ANODE", index++);
//             AddWord("ANTIC", index++);
//             AddWord("ANVIL", index++);
//             AddWord("AORTA", index++);
//             AddWord("APART", index++);
//             AddWord("APHID", index++);
//             AddWord("APING", index++);
//             AddWord("APNEA", index++);
//             AddWord("APPLE", index++);
//             AddWord("APPLY", index++);
//             AddWord("APRON", index++);
//             AddWord("APTLY", index++);
//             AddWord("ARBOR", index++);
//             AddWord("ARDOR", index++);
//             AddWord("ARENA", index++);
//             AddWord("ARGUE", index++);
//             AddWord("ARISE", index++);
//             AddWord("ARMOR", index++);
//             AddWord("AROMA", index++);
//             AddWord("AROSE", index++);
//             AddWord("ARRAY", index++);
//             AddWord("ARROW", index++);
//             AddWord("ARSON", index++);
//             AddWord("ARTSY", index++);
//             AddWord("ASCOT", index++);
//             AddWord("ASHEN", index++);
//             AddWord("ASIDE", index++);
//             AddWord("ASKEW", index++);
//             AddWord("ASSAY", index++);
//             AddWord("ASSET", index++);
//             AddWord("ATOLL", index++);
//             AddWord("ATONE", index++);
//             AddWord("ATTIC", index++);
//             AddWord("AUDIO", index++);
//             AddWord("AUDIT", index++);
//             AddWord("AUGUR", index++);
//             AddWord("AUNTY", index++);
//             AddWord("AVAIL", index++);
//             AddWord("AVERT", index++);
//             AddWord("AVIAN", index++);
//             AddWord("AVOID", index++);
//             AddWord("AWAIT", index++);
//             AddWord("AWAKE", index++);
//             AddWord("AWARD", index++);
//             AddWord("AWARE", index++);
//             AddWord("AWASH", index++);
//             AddWord("AWFUL", index++);
//             AddWord("AWOKE", index++);
//             AddWord("AXIAL", index++);
//             AddWord("AXIOM", index++);
//             AddWord("AXION", index++);
//             AddWord("AZURE", index++);
//
//             bIndex = index;
//
//             AddWord("BACON", index++);
//             AddWord("BADGE", index++);
//             AddWord("BADLY", index++);
//             AddWord("BAGEL", index++);
//             AddWord("BAGGY", index++);
//             AddWord("BAKER", index++);
//             AddWord("BALER", index++);
//             AddWord("BALMY", index++);
//             AddWord("BANAL", index++);
//             AddWord("BANJO", index++);
//             AddWord("BARGE", index++);
//             AddWord("BARON", index++);
//             AddWord("BASAL", index++);
//             AddWord("BASIC", index++);
//             AddWord("BASIL", index++);
//             AddWord("BASIN", index++);
//             AddWord("BASIS", index++);
//             AddWord("BASTE", index++);
//             AddWord("BATCH", index++);
//             AddWord("BATHE", index++);
//             AddWord("BATON", index++);
//             AddWord("BATTY", index++);
//             AddWord("BAWDY", index++);
//             AddWord("BAYOU", index++);
//             AddWord("BEACH", index++);
//             AddWord("BEADY", index++);
//             AddWord("BEARD", index++);
//             AddWord("BEAST", index++);
//             AddWord("BEECH", index++);
//             AddWord("BEEFY", index++);
//             AddWord("BEFIT", index++);
//             AddWord("BEGAN", index++);
//             AddWord("BEGAT", index++);
//             AddWord("BEGET", index++);
//             AddWord("BEGIN", index++);
//             AddWord("BEGUN", index++);
//             AddWord("BEING", index++);
//             AddWord("BELCH", index++);
//             AddWord("BELIE", index++);
//             AddWord("BELLE", index++);
//             AddWord("BELLY", index++);
//             AddWord("BELOW", index++);
//             AddWord("BENCH", index++);
//             AddWord("BERET", index++);
//             AddWord("BERRY", index++);
//             AddWord("BERTH", index++);
//             AddWord("BESET", index++);
//             AddWord("BETEL", index++);
//             AddWord("BEVEL", index++);
//             AddWord("BEZEL", index++);
//             AddWord("BIBLE", index++);
//             AddWord("BICEP", index++);
//             AddWord("BIDDY", index++);
//             AddWord("BIGOT", index++);
//             AddWord("BILGE", index++);
//             AddWord("BILLY", index++);
//             AddWord("BINGE", index++);
//             AddWord("BINGO", index++);
//             AddWord("BIOME", index++);
//             AddWord("BIRCH", index++);
//             AddWord("BIRTH", index++);
//             AddWord("BISON", index++);
//             AddWord("BITTY", index++);
//             AddWord("BLACK", index++);
//             AddWord("BLADE", index++);
//             AddWord("BLAME", index++);
//             AddWord("BLAND", index++);
//             AddWord("BLANK", index++);
//             AddWord("BLARE", index++);
//             AddWord("BLAST", index++);
//             AddWord("BLAZE", index++);
//             AddWord("BLEAK", index++);
//             AddWord("BLEAT", index++);
//             AddWord("BLEED", index++);
//             AddWord("BLEEP", index++);
//             AddWord("BLEND", index++);
//             AddWord("BLESS", index++);
//             AddWord("BLIMP", index++);
//             AddWord("BLIND", index++);
//             AddWord("BLINK", index++);
//             AddWord("BLISS", index++);
//             AddWord("BLITZ", index++);
//             AddWord("BLOAT", index++);
//             AddWord("BLOCK", index++);
//             AddWord("BLOKE", index++);
//             AddWord("BLOND", index++);
//             AddWord("BLOOD", index++);
//             AddWord("BLOOM", index++);
//             AddWord("BLOWN", index++);
//             AddWord("BLUER", index++);
//             AddWord("BLUFF", index++);
//             AddWord("BLUNT", index++);
//             AddWord("BLURB", index++);
//             AddWord("BLURT", index++);
//             AddWord("BLUSH", index++);
//             AddWord("BOARD", index++);
//             AddWord("BOAST", index++);
//             AddWord("BOBBY", index++);
//             AddWord("BONEY", index++);
//             AddWord("BONGO", index++);
//             AddWord("BONUS", index++);
//             AddWord("BOOBY", index++);
//             AddWord("BOOST", index++);
//             AddWord("BOOTH", index++);
//             AddWord("BOOTY", index++);
//             AddWord("BOOZE", index++);
//             AddWord("BOOZY", index++);
//             AddWord("BORAX", index++);
//             AddWord("BORNE", index++);
//             AddWord("BOSOM", index++);
//             AddWord("BOSSY", index++);
//             AddWord("BOTCH", index++);
//             AddWord("BOUGH", index++);
//             AddWord("BOULE", index++);
//             AddWord("BOUND", index++);
//             AddWord("BOWEL", index++);
//             AddWord("BOXER", index++);
//             AddWord("BRACE", index++);
//             AddWord("BRAID", index++);
//             AddWord("BRAIN", index++);
//             AddWord("BRAKE", index++);
//             AddWord("BRAND", index++);
//             AddWord("BRASH", index++);
//             AddWord("BRASS", index++);
//             AddWord("BRAVE", index++);
//             AddWord("BRAVO", index++);
//             AddWord("BRAWL", index++);
//             AddWord("BRAWN", index++);
//             AddWord("BREAD", index++);
//             AddWord("BREAK", index++);
//             AddWord("BREED", index++);
//             AddWord("BRIAR", index++);
//             AddWord("BRIBE", index++);
//             AddWord("BRICK", index++);
//             AddWord("BRIDE", index++);
//             AddWord("BRIEF", index++);
//             AddWord("BRINE", index++);
//             AddWord("BRING", index++);
//             AddWord("BRINK", index++);
//             AddWord("BRINY", index++);
//             AddWord("BRISK", index++);
//             AddWord("BROAD", index++);
//             AddWord("BROIL", index++);
//             AddWord("BROKE", index++);
//             AddWord("BROOD", index++);
//             AddWord("BROOK", index++);
//             AddWord("BROOM", index++);
//             AddWord("BROTH", index++);
//             AddWord("BROWN", index++);
//             AddWord("BRUNT", index++);
//             AddWord("BRUSH", index++);
//             AddWord("BRUTE", index++);
//             AddWord("BUDDY", index++);
//             AddWord("BUDGE", index++);
//             AddWord("BUGGY", index++);
//             AddWord("BUGLE", index++);
//             AddWord("BUILD", index++);
//             AddWord("BUILT", index++);
//             AddWord("BULGE", index++);
//             AddWord("BULKY", index++);
//             AddWord("BULLY", index++);
//             AddWord("BUNCH", index++);
//             AddWord("BUNNY", index++);
//             AddWord("BURLY", index++);
//             AddWord("BURNT", index++);
//             AddWord("BURST", index++);
//             AddWord("BUSED", index++);
//             AddWord("BUSHY", index++);
//             AddWord("BUTCH", index++);
//             AddWord("BUTTE", index++);
//             AddWord("BUXOM", index++);
//             AddWord("BUYER", index++);
//             AddWord("BYLAW", index++);
//
//             cIndex = index;
//
//             AddWord("CABAL", index++);
//             AddWord("CABBY", index++);
//             AddWord("CABIN", index++);
//             AddWord("CABLE", index++);
//             AddWord("CACAO", index++);
//             AddWord("CACHE", index++);
//             AddWord("CACTI", index++);
//             AddWord("CADDY", index++);
//             AddWord("CADET", index++);
//             AddWord("CAGEY", index++);
//             AddWord("CAIRN", index++);
//             AddWord("CAMEL", index++);
//             AddWord("CAMEO", index++);
//             AddWord("CANAL", index++);
//             AddWord("CANDY", index++);
//             AddWord("CANNY", index++);
//             AddWord("CANOE", index++);
//             AddWord("CANON", index++);
//             AddWord("CAPER", index++);
//             AddWord("CAPUT", index++);
//             AddWord("CARAT", index++);
//             AddWord("CARGO", index++);
//             AddWord("CAROL", index++);
//             AddWord("CARRY", index++);
//             AddWord("CARVE", index++);
//             AddWord("CASTE", index++);
//             AddWord("CATCH", index++);
//             AddWord("CATER", index++);
//             AddWord("CATTY", index++);
//             AddWord("CAULK", index++);
//             AddWord("CAUSE", index++);
//             AddWord("CAVIL", index++);
//             AddWord("CEASE", index++);
//             AddWord("CEDAR", index++);
//             AddWord("CELLO", index++);
//             AddWord("CHAFE", index++);
//             AddWord("CHAFF", index++);
//             AddWord("CHAIN", index++);
//             AddWord("CHAIR", index++);
//             AddWord("CHALK", index++);
//             AddWord("CHAMP", index++);
//             AddWord("CHANT", index++);
//             AddWord("CHAOS", index++);
//             AddWord("CHARD", index++);
//             AddWord("CHARM", index++);
//             AddWord("CHART", index++);
//             AddWord("CHASE", index++);
//             AddWord("CHASM", index++);
//             AddWord("CHEAP", index++);
//             AddWord("CHEAT", index++);
//             AddWord("CHECK", index++);
//             AddWord("CHEEK", index++);
//             AddWord("CHEER", index++);
//             AddWord("CHESS", index++);
//             AddWord("CHEST", index++);
//             AddWord("CHICK", index++);
//             AddWord("CHIDE", index++);
//             AddWord("CHIEF", index++);
//             AddWord("CHILD", index++);
//             AddWord("CHILI", index++);
//             AddWord("CHILL", index++);
//             AddWord("CHIME", index++);
//             AddWord("CHINA", index++);
//             AddWord("CHIRP", index++);
//             AddWord("CHOCK", index++);
//             AddWord("CHOIR", index++);
//             AddWord("CHOKE", index++);
//             AddWord("CHORD", index++);
//             AddWord("CHORE", index++);
//             AddWord("CHOSE", index++);
//             AddWord("CHUCK", index++);
//             AddWord("CHUMP", index++);
//             AddWord("CHUNK", index++);
//             AddWord("CHURN", index++);
//             AddWord("CHUTE", index++);
//             AddWord("CIDER", index++);
//             AddWord("CIGAR", index++);
//             AddWord("CINCH", index++);
//             AddWord("CIRCA", index++);
//             AddWord("CIVIC", index++);
//             AddWord("CIVIL", index++);
//             AddWord("CLACK", index++);
//             AddWord("CLAIM", index++);
//             AddWord("CLAMP", index++);
//             AddWord("CLANG", index++);
//             AddWord("CLANK", index++);
//             AddWord("CLASH", index++);
//             AddWord("CLASP", index++);
//             AddWord("CLASS", index++);
//             AddWord("CLEAN", index++);
//             AddWord("CLEAR", index++);
//             AddWord("CLEAT", index++);
//             AddWord("CLEFT", index++);
//             AddWord("CLERK", index++);
//             AddWord("CLICK", index++);
//             AddWord("CLIFF", index++);
//             AddWord("CLIMB", index++);
//             AddWord("CLING", index++);
//             AddWord("CLINK", index++);
//             AddWord("CLOAK", index++);
//             AddWord("CLOCK", index++);
//             AddWord("CLONE", index++);
//             AddWord("CLOSE", index++);
//             AddWord("CLOTH", index++);
//             AddWord("CLOUD", index++);
//             AddWord("CLOUT", index++);
//             AddWord("CLOVE", index++);
//             AddWord("CLOWN", index++);
//             AddWord("CLUCK", index++);
//             AddWord("CLUED", index++);
//             AddWord("CLUMP", index++);
//             AddWord("CLUNG", index++);
//             AddWord("COACH", index++);
//             AddWord("COAST", index++);
//             AddWord("COBRA", index++);
//             AddWord("COCOA", index++);
//             AddWord("COLON", index++);
//             AddWord("COLOR", index++);
//             AddWord("COMET", index++);
//             AddWord("COMFY", index++);
//             AddWord("COMIC", index++);
//             AddWord("COMMA", index++);
//             AddWord("CONCH", index++);
//             AddWord("CONDO", index++);
//             AddWord("CONIC", index++);
//             AddWord("COPSE", index++);
//             AddWord("CORAL", index++);
//             AddWord("CORER", index++);
//             AddWord("CORNY", index++);
//             AddWord("COUCH", index++);
//             AddWord("COUGH", index++);
//             AddWord("COULD", index++);
//             AddWord("COUNT", index++);
//             AddWord("COUPE", index++);
//             AddWord("COURT", index++);
//             AddWord("COVEN", index++);
//             AddWord("COVER", index++);
//             AddWord("COVET", index++);
//             AddWord("COVEY", index++);
//             AddWord("COWER", index++);
//             AddWord("COYLY", index++);
//             AddWord("CRACK", index++);
//             AddWord("CRAFT", index++);
//             AddWord("CRAMP", index++);
//             AddWord("CRANE", index++);
//             AddWord("CRANK", index++);
//             AddWord("CRASH", index++);
//             AddWord("CRASS", index++);
//             AddWord("CRATE", index++);
//             AddWord("CRAVE", index++);
//             AddWord("CRAWL", index++);
//             AddWord("CRAZE", index++);
//             AddWord("CRAZY", index++);
//             AddWord("CREAK", index++);
//             AddWord("CREAM", index++);
//             AddWord("CREDO", index++);
//             AddWord("CREED", index++);
//             AddWord("CREEK", index++);
//             AddWord("CREEP", index++);
//             AddWord("CREME", index++);
//             AddWord("CREPE", index++);
//             AddWord("CREPT", index++);
//             AddWord("CRESS", index++);
//             AddWord("CREST", index++);
//             AddWord("CRICK", index++);
//             AddWord("CRIED", index++);
//             AddWord("CRIER", index++);
//             AddWord("CRIME", index++);
//             AddWord("CRIMP", index++);
//             AddWord("CRISP", index++);
//             AddWord("CROAK", index++);
//             AddWord("CROCK", index++);
//             AddWord("CRONE", index++);
//             AddWord("CRONY", index++);
//             AddWord("CROOK", index++);
//             AddWord("CROSS", index++);
//             AddWord("CROUP", index++);
//             AddWord("CROWD", index++);
//             AddWord("CROWN", index++);
//             AddWord("CRUDE", index++);
//             AddWord("CRUEL", index++);
//             AddWord("CRUMB", index++);
//             AddWord("CRUMP", index++);
//             AddWord("CRUSH", index++);
//             AddWord("CRUST", index++);
//             AddWord("CRYPT", index++);
//             AddWord("CUBIC", index++);
//             AddWord("CUMIN", index++);
//             AddWord("CURIO", index++);
//             AddWord("CURLY", index++);
//             AddWord("CURRY", index++);
//             AddWord("CURSE", index++);
//             AddWord("CURVE", index++);
//             AddWord("CURVY", index++);
//             AddWord("CUTIE", index++);
//             AddWord("CYBER", index++);
//             AddWord("CYCLE", index++);
//             AddWord("CYNIC", index++);
//
//             dIndex = index;
//
//             AddWord("DADDY", index++);
//             AddWord("DAILY", index++);
//             AddWord("DAIRY", index++);
//             AddWord("DAISY", index++);
//             AddWord("DALLY", index++);
//             AddWord("DANCE", index++);
//             AddWord("DANDY", index++);
//             AddWord("DATUM", index++);
//             AddWord("DAUNT", index++);
//             AddWord("DEALT", index++);
//             AddWord("DEATH", index++);
//             AddWord("DEBAR", index++);
//             AddWord("DEBIT", index++);
//             AddWord("DEBUG", index++);
//             AddWord("DEBUT", index++);
//             AddWord("DECAL", index++);
//             AddWord("DECAY", index++);
//             AddWord("DECOR", index++);
//             AddWord("DECOY", index++);
//             AddWord("DECRY", index++);
//             AddWord("DEFER", index++);
//             AddWord("DEIGN", index++);
//             AddWord("DEITY", index++);
//             AddWord("DELAY", index++);
//             AddWord("DELTA", index++);
//             AddWord("DELVE", index++);
//             AddWord("DEMON", index++);
//             AddWord("DEMUR", index++);
//             AddWord("DENIM", index++);
//             AddWord("DENSE", index++);
//             AddWord("DEPOT", index++);
//             AddWord("DEPTH", index++);
//             AddWord("DERBY", index++);
//             AddWord("DETER", index++);
//             AddWord("DETOX", index++);
//             AddWord("DEUCE", index++);
//             AddWord("DEVIL", index++);
//             AddWord("DIARY", index++);
//             AddWord("DICEY", index++);
//             AddWord("DIGIT", index++);
//             AddWord("DILLY", index++);
//             AddWord("DIMLY", index++);
//             AddWord("DINER", index++);
//             AddWord("DINGO", index++);
//             AddWord("DINGY", index++);
//             AddWord("DIODE", index++);
//             AddWord("DIRGE", index++);
//             AddWord("DIRTY", index++);
//             AddWord("DISCO", index++);
//             AddWord("DITCH", index++);
//             AddWord("DITTO", index++);
//             AddWord("DITTY", index++);
//             AddWord("DIVER", index++);
//             AddWord("DIZZY", index++);
//             AddWord("DODGE", index++);
//             AddWord("DODGY", index++);
//             AddWord("DOGMA", index++);
//             AddWord("DOING", index++);
//             AddWord("DOLLY", index++);
//             AddWord("DONOR", index++);
//             AddWord("DONUT", index++);
//             AddWord("DOPEY", index++);
//             AddWord("DOUBT", index++);
//             AddWord("DOUGH", index++);
//             AddWord("DOWDY", index++);
//             AddWord("DOWEL", index++);
//             AddWord("DOWNY", index++);
//             AddWord("DOWRY", index++);
//             AddWord("DOZEN", index++);
//             AddWord("DRAFT", index++);
//             AddWord("DRAIN", index++);
//             AddWord("DRAKE", index++);
//             AddWord("DRAMA", index++);
//             AddWord("DRANK", index++);
//             AddWord("DRAPE", index++);
//             AddWord("DRAWL", index++);
//             AddWord("DRAWN", index++);
//             AddWord("DREAD", index++);
//             AddWord("DREAM", index++);
//             AddWord("DRESS", index++);
//             AddWord("DRIED", index++);
//             AddWord("DRIER", index++);
//             AddWord("DRIFT", index++);
//             AddWord("DRILL", index++);
//             AddWord("DRINK", index++);
//             AddWord("DRIVE", index++);
//             AddWord("DROIT", index++);
//             AddWord("DROLL", index++);
//             AddWord("DRONE", index++);
//             AddWord("DROOL", index++);
//             AddWord("DROOP", index++);
//             AddWord("DROSS", index++);
//             AddWord("DROVE", index++);
//             AddWord("DROWN", index++);
//             AddWord("DRUID", index++);
//             AddWord("DRUNK", index++);
//             AddWord("DRYER", index++);
//             AddWord("DRYLY", index++);
//             AddWord("DUCHY", index++);
//             AddWord("DULLY", index++);
//             AddWord("DUMMY", index++);
//             AddWord("DUMPY", index++);
//             AddWord("DUNCE", index++);
//             AddWord("DUSKY", index++);
//             AddWord("DUSTY", index++);
//             AddWord("DUTCH", index++);
//             AddWord("DUVET", index++);
//             AddWord("DWARF", index++);
//             AddWord("DWELL", index++);
//             AddWord("DWELT", index++);
//             AddWord("DYING", index++);
//
//             eIndex = index;
//
//             AddWord("EAGER", index++);
//             AddWord("EAGLE", index++);
//             AddWord("EARLY", index++);
//             AddWord("EARTH", index++);
//             AddWord("EASEL", index++);
//             AddWord("EATEN", index++);
//             AddWord("EATER", index++);
//             AddWord("EBONY", index++);
//             AddWord("ECLAT", index++);
//             AddWord("EDICT", index++);
//             AddWord("EDIFY", index++);
//             AddWord("EERIE", index++);
//             AddWord("EGRET", index++);
//             AddWord("EIGHT", index++);
//             AddWord("EJECT", index++);
//             AddWord("EKING", index++);
//             AddWord("ELATE", index++);
//             AddWord("ELBOW", index++);
//             AddWord("ELDER", index++);
//             AddWord("ELECT", index++);
//             AddWord("ELEGY", index++);
//             AddWord("ELFIN", index++);
//             AddWord("ELIDE", index++);
//             AddWord("ELITE", index++);
//             AddWord("ELOPE", index++);
//             AddWord("ELUDE", index++);
//             AddWord("EMAIL", index++);
//             AddWord("EMBED", index++);
//             AddWord("EMBER", index++);
//             AddWord("EMCEE", index++);
//             AddWord("EMPTY", index++);
//             AddWord("ENACT", index++);
//             AddWord("ENDOW", index++);
//             AddWord("ENEMA", index++);
//             AddWord("ENEMY", index++);
//             AddWord("ENJOY", index++);
//             AddWord("ENNUI", index++);
//             AddWord("ENSUE", index++);
//             AddWord("ENTER", index++);
//             AddWord("ENTRY", index++);
//             AddWord("ENVOY", index++);
//             AddWord("EPOCH", index++);
//             AddWord("EPOXY", index++);
//             AddWord("EQUAL", index++);
//             AddWord("EQUIP", index++);
//             AddWord("ERASE", index++);
//             AddWord("ERECT", index++);
//             AddWord("ERODE", index++);
//             AddWord("ERROR", index++);
//             AddWord("ERUPT", index++);
//             AddWord("ESSAY", index++);
//             AddWord("ESTER", index++);
//             AddWord("ETHER", index++);
//             AddWord("ETHIC", index++);
//             AddWord("ETHOS", index++);
//             AddWord("ETUDE", index++);
//             AddWord("EVADE", index++);
//             AddWord("EVENT", index++);
//             AddWord("EVERY", index++);
//             AddWord("EVICT", index++);
//             AddWord("EVOKE", index++);
//             AddWord("EXACT", index++);
//             AddWord("EXALT", index++);
//             AddWord("EXCEL", index++);
//             AddWord("EXERT", index++);
//             AddWord("EXILE", index++);
//             AddWord("EXIST", index++);
//             AddWord("EXPEL", index++);
//             AddWord("EXTOL", index++);
//             AddWord("EXTRA", index++);
//             AddWord("EXULT", index++);
//             AddWord("EYING", index++);
//
//             fIndex = index;
//
//             AddWord("FABLE", index++);
//             AddWord("FACET", index++);
//             AddWord("FAINT", index++);
//             AddWord("FAIRY", index++);
//             AddWord("FAITH", index++);
//             AddWord("FALSE", index++);
//             AddWord("FANCY", index++);
//             AddWord("FANNY", index++);
//             AddWord("FARCE", index++);
//             AddWord("FATAL", index++);
//             AddWord("FATTY", index++);
//             AddWord("FAULT", index++);
//             AddWord("FAUNA", index++);
//             AddWord("FAVOR", index++);
//             AddWord("FEAST", index++);
//             AddWord("FECAL", index++);
//             AddWord("FEIGN", index++);
//             AddWord("FELLA", index++);
//             AddWord("FELON", index++);
//             AddWord("FEMME", index++);
//             AddWord("FEMUR", index++);
//             AddWord("FENCE", index++);
//             AddWord("FERAL", index++);
//             AddWord("FERRY", index++);
//             AddWord("FETAL", index++);
//             AddWord("FETCH", index++);
//             AddWord("FETID", index++);
//             AddWord("FETUS", index++);
//             AddWord("FEVER", index++);
//             AddWord("FEWER", index++);
//             AddWord("FIBER", index++);
//             AddWord("FICUS", index++);
//             AddWord("FIELD", index++);
//             AddWord("FIEND", index++);
//             AddWord("FIERY", index++);
//             AddWord("FIFTH", index++);
//             AddWord("FIFTY", index++);
//             AddWord("FIGHT", index++);
//             AddWord("FILER", index++);
//             AddWord("FILET", index++);
//             AddWord("FILLY", index++);
//             AddWord("FILMY", index++);
//             AddWord("FILTH", index++);
//             AddWord("FINAL", index++);
//             AddWord("FINCH", index++);
//             AddWord("FINER", index++);
//             AddWord("FIRST", index++);
//             AddWord("FISHY", index++);
//             AddWord("FIXER", index++);
//             AddWord("FIZZY", index++);
//             AddWord("FJORD", index++);
//             AddWord("FLACK", index++);
//             AddWord("FLAIL", index++);
//             AddWord("FLAIR", index++);
//             AddWord("FLAKE", index++);
//             AddWord("FLAKY", index++);
//             AddWord("FLAME", index++);
//             AddWord("FLANK", index++);
//             AddWord("FLARE", index++);
//             AddWord("FLASH", index++);
//             AddWord("FLASK", index++);
//             AddWord("FLECK", index++);
//             AddWord("FLEET", index++);
//             AddWord("FLESH", index++);
//             AddWord("FLICK", index++);
//             AddWord("FLIER", index++);
//             AddWord("FLING", index++);
//             AddWord("FLINT", index++);
//             AddWord("FLIRT", index++);
//             AddWord("FLOAT", index++);
//             AddWord("FLOCK", index++);
//             AddWord("FLOOD", index++);
//             AddWord("FLOOR", index++);
//             AddWord("FLORA", index++);
//             AddWord("FLOSS", index++);
//             AddWord("FLOUR", index++);
//             AddWord("FLOUT", index++);
//             AddWord("FLOWN", index++);
//             AddWord("FLUFF", index++);
//             AddWord("FLUID", index++);
//             AddWord("FLUKE", index++);
//             AddWord("FLUME", index++);
//             AddWord("FLUNG", index++);
//             AddWord("FLUNK", index++);
//             AddWord("FLUSH", index++);
//             AddWord("FLUTE", index++);
//             AddWord("FLYER", index++);
//             AddWord("FOAMY", index++);
//             AddWord("FOCAL", index++);
//             AddWord("FOCUS", index++);
//             AddWord("FOGGY", index++);
//             AddWord("FOIST", index++);
//             AddWord("FOLIO", index++);
//             AddWord("FOLLY", index++);
//             AddWord("FORAY", index++);
//             AddWord("FORCE", index++);
//             AddWord("FORGE", index++);
//             AddWord("FORGO", index++);
//             AddWord("FORTE", index++);
//             AddWord("FORTH", index++);
//             AddWord("FORTY", index++);
//             AddWord("FORUM", index++);
//             AddWord("FOUND", index++);
//             AddWord("FOYER", index++);
//             AddWord("FRAIL", index++);
//             AddWord("FRAME", index++);
//             AddWord("FRANK", index++);
//             AddWord("FRAUD", index++);
//             AddWord("FREAK", index++);
//             AddWord("FREED", index++);
//             AddWord("FREER", index++);
//             AddWord("FRESH", index++);
//             AddWord("FRIAR", index++);
//             AddWord("FRIED", index++);
//             AddWord("FRILL", index++);
//             AddWord("FRISK", index++);
//             AddWord("FRITZ", index++);
//             AddWord("FROCK", index++);
//             AddWord("FROND", index++);
//             AddWord("FRONT", index++);
//             AddWord("FROST", index++);
//             AddWord("FROTH", index++);
//             AddWord("FROWN", index++);
//             AddWord("FROZE", index++);
//             AddWord("FRUIT", index++);
//             AddWord("FUDGE", index++);
//             AddWord("FUGUE", index++);
//             AddWord("FULLY", index++);
//             AddWord("FUNGI", index++);
//             AddWord("FUNKY", index++);
//             AddWord("FUNNY", index++);
//             AddWord("FUROR", index++);
//             AddWord("FURRY", index++);
//             AddWord("FUSSY", index++);
//             AddWord("FUZZY", index++);
//
//             gIndex = index;
//
//             AddWord("GAFFE", index++);
//             AddWord("GAILY", index++);
//             AddWord("GAMER", index++);
//             AddWord("GAMMA", index++);
//             AddWord("GAMUT", index++);
//             AddWord("GASSY", index++);
//             AddWord("GAUDY", index++);
//             AddWord("GAUGE", index++);
//             AddWord("GAUNT", index++);
//             AddWord("GAUZE", index++);
//             AddWord("GAVEL", index++);
//             AddWord("GAWKY", index++);
//             AddWord("GAYER", index++);
//             AddWord("GAYLY", index++);
//             AddWord("GAZER", index++);
//             AddWord("GECKO", index++);
//             AddWord("GEEKY", index++);
//             AddWord("GEESE", index++);
//             AddWord("GENIE", index++);
//             AddWord("GENRE", index++);
//             AddWord("GHOST", index++);
//             AddWord("GHOUL", index++);
//             AddWord("GIANT", index++);
//             AddWord("GIDDY", index++);
//             AddWord("GIPSY", index++);
//             AddWord("GIRLY", index++);
//             AddWord("GIRTH", index++);
//             AddWord("GIVEN", index++);
//             AddWord("GIVER", index++);
//             AddWord("GLADE", index++);
//             AddWord("GLAND", index++);
//             AddWord("GLARE", index++);
//             AddWord("GLASS", index++);
//             AddWord("GLAZE", index++);
//             AddWord("GLEAM", index++);
//             AddWord("GLEAN", index++);
//             AddWord("GLIDE", index++);
//             AddWord("GLINT", index++);
//             AddWord("GLOAT", index++);
//             AddWord("GLOBE", index++);
//             AddWord("GLOOM", index++);
//             AddWord("GLORY", index++);
//             AddWord("GLOSS", index++);
//             AddWord("GLOVE", index++);
//             AddWord("GLYPH", index++);
//             AddWord("GNASH", index++);
//             AddWord("GNOME", index++);
//             AddWord("GODLY", index++);
//             AddWord("GOING", index++);
//             AddWord("GOLEM", index++);
//             AddWord("GOLLY", index++);
//             AddWord("GONAD", index++);
//             AddWord("GONER", index++);
//             AddWord("GOODY", index++);
//             AddWord("GOOEY", index++);
//             AddWord("GOOFY", index++);
//             AddWord("GOOSE", index++);
//             AddWord("GORGE", index++);
//             AddWord("GOUGE", index++);
//             AddWord("GOURD", index++);
//             AddWord("GRACE", index++);
//             AddWord("GRADE", index++);
//             AddWord("GRAFT", index++);
//             AddWord("GRAIL", index++);
//             AddWord("GRAIN", index++);
//             AddWord("GRAND", index++);
//             AddWord("GRANT", index++);
//             AddWord("GRAPE", index++);
//             AddWord("GRAPH", index++);
//             AddWord("GRASP", index++);
//             AddWord("GRASS", index++);
//             AddWord("GRATE", index++);
//             AddWord("GRAVE", index++);
//             AddWord("GRAVY", index++);
//             AddWord("GRAZE", index++);
//             AddWord("GREAT", index++);
//             AddWord("GREED", index++);
//             AddWord("GREEN", index++);
//             AddWord("GREET", index++);
//             AddWord("GRIEF", index++);
//             AddWord("GRILL", index++);
//             AddWord("GRIME", index++);
//             AddWord("GRIMY", index++);
//             AddWord("GRIND", index++);
//             AddWord("GRIPE", index++);
//             AddWord("GROAN", index++);
//             AddWord("GROIN", index++);
//             AddWord("GROOM", index++);
//             AddWord("GROPE", index++);
//             AddWord("GROSS", index++);
//             AddWord("GROUP", index++);
//             AddWord("GROUT", index++);
//             AddWord("GROVE", index++);
//             AddWord("GROWL", index++);
//             AddWord("GROWN", index++);
//             AddWord("GRUEL", index++);
//             AddWord("GRUFF", index++);
//             AddWord("GRUNT", index++);
//             AddWord("GUARD", index++);
//             AddWord("GUAVA", index++);
//             AddWord("GUESS", index++);
//             AddWord("GUEST", index++);
//             AddWord("GUIDE", index++);
//             AddWord("GUILD", index++);
//             AddWord("GUILE", index++);
//             AddWord("GUILT", index++);
//             AddWord("GUISE", index++);
//             AddWord("GULCH", index++);
//             AddWord("GULLY", index++);
//             AddWord("GUMBO", index++);
//             AddWord("GUMMY", index++);
//             AddWord("GUPPY", index++);
//             AddWord("GUSTO", index++);
//             AddWord("GUSTY", index++);
//             AddWord("GYPSY", index++);
//
//             hIndex = index;
//
//             AddWord("HABIT", index++);
//             AddWord("HAIRY", index++);
//             AddWord("HALVE", index++);
//             AddWord("HANDY", index++);
//             AddWord("HAPPY", index++);
//             AddWord("HARDY", index++);
//             AddWord("HAREM", index++);
//             AddWord("HARPY", index++);
//             AddWord("HARRY", index++);
//             AddWord("HARSH", index++);
//             AddWord("HASTE", index++);
//             AddWord("HASTY", index++);
//             AddWord("HATCH", index++);
//             AddWord("HATER", index++);
//             AddWord("HAUNT", index++);
//             AddWord("HAUTE", index++);
//             AddWord("HAVEN", index++);
//             AddWord("HAVOC", index++);
//             AddWord("HAZEL", index++);
//             AddWord("HEADY", index++);
//             AddWord("HEARD", index++);
//             AddWord("HEART", index++);
//             AddWord("HEATH", index++);
//             AddWord("HEAVE", index++);
//             AddWord("HEAVY", index++);
//             AddWord("HEDGE", index++);
//             AddWord("HEFTY", index++);
//             AddWord("HEIST", index++);
//             AddWord("HELIX", index++);
//             AddWord("HELLO", index++);
//             AddWord("HENCE", index++);
//             AddWord("HERON", index++);
//             AddWord("HILLY", index++);
//             AddWord("HINGE", index++);
//             AddWord("HIPPO", index++);
//             AddWord("HIPPY", index++);
//             AddWord("HITCH", index++);
//             AddWord("HOARD", index++);
//             AddWord("HOBBY", index++);
//             AddWord("HOIST", index++);
//             AddWord("HOLLY", index++);
//             AddWord("HOMER", index++);
//             AddWord("HONEY", index++);
//             AddWord("HONOR", index++);
//             AddWord("HORDE", index++);
//             AddWord("HORNY", index++);
//             AddWord("HORSE", index++);
//             AddWord("HOTEL", index++);
//             AddWord("HOTLY", index++);
//             AddWord("HOUND", index++);
//             AddWord("HOUSE", index++);
//             AddWord("HOVEL", index++);
//             AddWord("HOVER", index++);
//             AddWord("HOWDY", index++);
//             AddWord("HUMAN", index++);
//             AddWord("HUMID", index++);
//             AddWord("HUMOR", index++);
//             AddWord("HUMPH", index++);
//             AddWord("HUMUS", index++);
//             AddWord("HUNCH", index++);
//             AddWord("HUNKY", index++);
//             AddWord("HURRY", index++);
//             AddWord("HUSKY", index++);
//             AddWord("HUSSY", index++);
//             AddWord("HUTCH", index++);
//             AddWord("HYDRO", index++);
//             AddWord("HYENA", index++);
//             AddWord("HYMEN", index++);
//             AddWord("HYPER", index++);
//
//             iIndex = index;
//
//             AddWord("ICILY", index++);
//             AddWord("ICING", index++);
//             AddWord("IDEAL", index++);
//             AddWord("IDIOM", index++);
//             AddWord("IDIOT", index++);
//             AddWord("IDLER", index++);
//             AddWord("IDYLL", index++);
//             AddWord("IGLOO", index++);
//             AddWord("ILIAC", index++);
//             AddWord("IMAGE", index++);
//             AddWord("IMBUE", index++);
//             AddWord("IMPEL", index++);
//             AddWord("IMPLY", index++);
//             AddWord("INANE", index++);
//             AddWord("INBOX", index++);
//             AddWord("INCUR", index++);
//             AddWord("INDEX", index++);
//             AddWord("INEPT", index++);
//             AddWord("INERT", index++);
//             AddWord("INFER", index++);
//             AddWord("INGOT", index++);
//             AddWord("INLAY", index++);
//             AddWord("INLET", index++);
//             AddWord("INNER", index++);
//             AddWord("INPUT", index++);
//             AddWord("INTER", index++);
//             AddWord("INTRO", index++);
//             AddWord("IONIC", index++);
//             AddWord("IRATE", index++);
//             AddWord("IRONY", index++);
//             AddWord("ISLET", index++);
//             AddWord("ISSUE", index++);
//             AddWord("ITCHY", index++);
//             AddWord("IVORY", index++);
//
//             jIndex = index;
//
//             AddWord("JAUNT", index++);
//             AddWord("JAZZY", index++);
//             AddWord("JELLY", index++);
//             AddWord("JERKY", index++);
//             AddWord("JETTY", index++);
//             AddWord("JEWEL", index++);
//             AddWord("JIFFY", index++);
//             AddWord("JOINT", index++);
//             AddWord("JOIST", index++);
//             AddWord("JOKER", index++);
//             AddWord("JOLLY", index++);
//             AddWord("JOUST", index++);
//             AddWord("JUDGE", index++);
//             AddWord("JUICE", index++);
//             AddWord("JUICY", index++);
//             AddWord("JUMBO", index++);
//             AddWord("JUMPY", index++);
//             AddWord("JUNTA", index++);
//             AddWord("JUNTO", index++);
//             AddWord("JUROR", index++);
//
//             kIndex = index;
//
//             AddWord("KAPPA", index++);
//             AddWord("KARMA", index++);
//             AddWord("KAYAK", index++);
//             AddWord("KEBAB", index++);
//             AddWord("KHAKI", index++);
//             AddWord("KINKY", index++);
//             AddWord("KIOSK", index++);
//             AddWord("KITTY", index++);
//             AddWord("KNACK", index++);
//             AddWord("KNAVE", index++);
//             AddWord("KNEAD", index++);
//             AddWord("KNEED", index++);
//             AddWord("KNEEL", index++);
//             AddWord("KNELT", index++);
//             AddWord("KNIFE", index++);
//             AddWord("KNOCK", index++);
//             AddWord("KNOLL", index++);
//             AddWord("KNOWN", index++);
//             AddWord("KOALA", index++);
//             AddWord("KRILL", index++);
//
//             lIndex = index;
//
//             AddWord("LABEL", index++);
//             AddWord("LABOR", index++);
//             AddWord("LADEN", index++);
//             AddWord("LADLE", index++);
//             AddWord("LAGER", index++);
//             AddWord("LANCE", index++);
//             AddWord("LANKY", index++);
//             AddWord("LAPEL", index++);
//             AddWord("LAPSE", index++);
//             AddWord("LARGE", index++);
//             AddWord("LARVA", index++);
//             AddWord("LASSO", index++);
//             AddWord("LATCH", index++);
//             AddWord("LATER", index++);
//             AddWord("LATHE", index++);
//             AddWord("LATTE", index++);
//             AddWord("LAUGH", index++);
//             AddWord("LAYER", index++);
//             AddWord("LEACH", index++);
//             AddWord("LEAFY", index++);
//             AddWord("LEAKY", index++);
//             AddWord("LEANT", index++);
//             AddWord("LEAPT", index++);
//             AddWord("LEARN", index++);
//             AddWord("LEASE", index++);
//             AddWord("LEASH", index++);
//             AddWord("LEAST", index++);
//             AddWord("LEAVE", index++);
//             AddWord("LEDGE", index++);
//             AddWord("LEECH", index++);
//             AddWord("LEERY", index++);
//             AddWord("LEFTY", index++);
//             AddWord("LEGAL", index++);
//             AddWord("LEGGY", index++);
//             AddWord("LEMON", index++);
//             AddWord("LEMUR", index++);
//             AddWord("LEPER", index++);
//             AddWord("LEVEL", index++);
//             AddWord("LEVER", index++);
//             AddWord("LIBEL", index++);
//             AddWord("LIEGE", index++);
//             AddWord("LIGHT", index++);
//             AddWord("LIKEN", index++);
//             AddWord("LILAC", index++);
//             AddWord("LIMBO", index++);
//             AddWord("LIMIT", index++);
//             AddWord("LINEN", index++);
//             AddWord("LINER", index++);
//             AddWord("LINGO", index++);
//             AddWord("LIPID", index++);
//             AddWord("LITHE", index++);
//             AddWord("LIVER", index++);
//             AddWord("LIVID", index++);
//             AddWord("LLAMA", index++);
//             AddWord("LOAMY", index++);
//             AddWord("LOATH", index++);
//             AddWord("LOBBY", index++);
//             AddWord("LOCAL", index++);
//             AddWord("LOCUS", index++);
//             AddWord("LODGE", index++);
//             AddWord("LOFTY", index++);
//             AddWord("LOGIC", index++);
//             AddWord("LOGIN", index++);
//             AddWord("LOOPY", index++);
//             AddWord("LOOSE", index++);
//             AddWord("LORRY", index++);
//             AddWord("LOSER", index++);
//             AddWord("LOUSE", index++);
//             AddWord("LOUSY", index++);
//             AddWord("LOVER", index++);
//             AddWord("LOWER", index++);
//             AddWord("LOWLY", index++);
//             AddWord("LOYAL", index++);
//             AddWord("LUCID", index++);
//             AddWord("LUCKY", index++);
//             AddWord("LUMEN", index++);
//             AddWord("LUMPY", index++);
//             AddWord("LUNAR", index++);
//             AddWord("LUNCH", index++);
//             AddWord("LUNGE", index++);
//             AddWord("LUPUS", index++);
//             AddWord("LURCH", index++);
//             AddWord("LURID", index++);
//             AddWord("LUSTY", index++);
//             AddWord("LYING", index++);
//             AddWord("LYMPH", index++);
//             AddWord("LYRIC", index++);
//
//             mIndex = index;
//
//             AddWord("MACAW", index++);
//             AddWord("MACHO", index++);
//             AddWord("MACRO", index++);
//             AddWord("MADAM", index++);
//             AddWord("MADLY", index++);
//             AddWord("MAFIA", index++);
//             AddWord("MAGIC", index++);
//             AddWord("MAGMA", index++);
//             AddWord("MAIZE", index++);
//             AddWord("MAJOR", index++);
//             AddWord("MAKER", index++);
//             AddWord("MAMBO", index++);
//             AddWord("MAMMA", index++);
//             AddWord("MAMMY", index++);
//             AddWord("MANGA", index++);
//             AddWord("MANGE", index++);
//             AddWord("MANGO", index++);
//             AddWord("MANGY", index++);
//             AddWord("MANIA", index++);
//             AddWord("MANIC", index++);
//             AddWord("MANLY", index++);
//             AddWord("MANOR", index++);
//             AddWord("MAPLE", index++);
//             AddWord("MARCH", index++);
//             AddWord("MARRY", index++);
//             AddWord("MARSH", index++);
//             AddWord("MASON", index++);
//             AddWord("MASSE", index++);
//             AddWord("MATCH", index++);
//             AddWord("MATEY", index++);
//             AddWord("MAUVE", index++);
//             AddWord("MAXIM", index++);
//             AddWord("MAYBE", index++);
//             AddWord("MAYOR", index++);
//             AddWord("MEALY", index++);
//             AddWord("MEANT", index++);
//             AddWord("MEATY", index++);
//             AddWord("MECCA", index++);
//             AddWord("MEDAL", index++);
//             AddWord("MEDIA", index++);
//             AddWord("MEDIC", index++);
//             AddWord("MELEE", index++);
//             AddWord("MELON", index++);
//             AddWord("MERCY", index++);
//             AddWord("MERGE", index++);
//             AddWord("MERIT", index++);
//             AddWord("MERRY", index++);
//             AddWord("METAL", index++);
//             AddWord("METER", index++);
//             AddWord("METRO", index++);
//             AddWord("MICRO", index++);
//             AddWord("MIDGE", index++);
//             AddWord("MIDST", index++);
//             AddWord("MIGHT", index++);
//             AddWord("MILKY", index++);
//             AddWord("MIMIC", index++);
//             AddWord("MINCE", index++);
//             AddWord("MINER", index++);
//             AddWord("MINIM", index++);
//             AddWord("MINOR", index++);
//             AddWord("MINTY", index++);
//             AddWord("MINUS", index++);
//             AddWord("MIRTH", index++);
//             AddWord("MISER", index++);
//             AddWord("MISSY", index++);
//             AddWord("MOCHA", index++);
//             AddWord("MODAL", index++);
//             AddWord("MODEL", index++);
//             AddWord("MODEM", index++);
//             AddWord("MOGUL", index++);
//             AddWord("MOIST", index++);
//             AddWord("MOLAR", index++);
//             AddWord("MOLDY", index++);
//             AddWord("MONEY", index++);
//             AddWord("MONTH", index++);
//             AddWord("MOODY", index++);
//             AddWord("MOOSE", index++);
//             AddWord("MORAL", index++);
//             AddWord("MORON", index++);
//             AddWord("MORPH", index++);
//             AddWord("MOSSY", index++);
//             AddWord("MOTEL", index++);
//             AddWord("MOTIF", index++);
//             AddWord("MOTOR", index++);
//             AddWord("MOTTO", index++);
//             AddWord("MOULT", index++);
//             AddWord("MOUND", index++);
//             AddWord("MOUNT", index++);
//             AddWord("MOURN", index++);
//             AddWord("MOUSE", index++);
//             AddWord("MOUTH", index++);
//             AddWord("MOVER", index++);
//             AddWord("MOVIE", index++);
//             AddWord("MOWER", index++);
//             AddWord("MUCKY", index++);
//             AddWord("MUCUS", index++);
//             AddWord("MUDDY", index++);
//             AddWord("MULCH", index++);
//             AddWord("MUMMY", index++);
//             AddWord("MUNCH", index++);
//             AddWord("MURAL", index++);
//             AddWord("MURKY", index++);
//             AddWord("MUSHY", index++);
//             AddWord("MUSIC", index++);
//             AddWord("MUSKY", index++);
//             AddWord("MUSTY", index++);
//             AddWord("MYRRH", index++);
//
//             nIndex = index;
//
//             AddWord("NADIR", index++);
//             AddWord("NAIVE", index++);
//             AddWord("NANNY", index++);
//             AddWord("NASAL", index++);
//             AddWord("NASTY", index++);
//             AddWord("NATAL", index++);
//             AddWord("NAVAL", index++);
//             AddWord("NAVEL", index++);
//             AddWord("NEEDY", index++);
//             AddWord("NEIGH", index++);
//             AddWord("NERDY", index++);
//             AddWord("NERVE", index++);
//             AddWord("NEVER", index++);
//             AddWord("NEWER", index++);
//             AddWord("NEWLY", index++);
//             AddWord("NICER", index++);
//             AddWord("NICHE", index++);
//             AddWord("NIECE", index++);
//             AddWord("NIGHT", index++);
//             AddWord("NINJA", index++);
//             AddWord("NINNY", index++);
//             AddWord("NINTH", index++);
//             AddWord("NOBLE", index++);
//             AddWord("NOBLY", index++);
//             AddWord("NOISE", index++);
//             AddWord("NOISY", index++);
//             AddWord("NOMAD", index++);
//             AddWord("NOOSE", index++);
//             AddWord("NORTH", index++);
//             AddWord("NOSEY", index++);
//             AddWord("NOTCH", index++);
//             AddWord("NOVEL", index++);
//             AddWord("NUDGE", index++);
//             AddWord("NURSE", index++);
//             AddWord("NUTTY", index++);
//             AddWord("NYLON", index++);
//             AddWord("NYMPH", index++);
//
//             oIndex = index;
//
//             AddWord("OAKEN", index++);
//             AddWord("OBESE", index++);
//             AddWord("OCCUR", index++);
//             AddWord("OCEAN", index++);
//             AddWord("OCTAL", index++);
//             AddWord("OCTET", index++);
//             AddWord("ODDER", index++);
//             AddWord("ODDLY", index++);
//             AddWord("OFFAL", index++);
//             AddWord("OFFER", index++);
//             AddWord("OFTEN", index++);
//             AddWord("OLDEN", index++);
//             AddWord("OLDER", index++);
//             AddWord("OLIVE", index++);
//             AddWord("OMBRE", index++);
//             AddWord("OMEGA", index++);
//             AddWord("ONION", index++);
//             AddWord("ONSET", index++);
//             AddWord("OPERA", index++);
//             AddWord("OPINE", index++);
//             AddWord("OPIUM", index++);
//             AddWord("OPTIC", index++);
//             AddWord("ORBIT", index++);
//             AddWord("ORDER", index++);
//             AddWord("ORGAN", index++);
//             AddWord("OTHER", index++);
//             AddWord("OTTER", index++);
//             AddWord("OUGHT", index++);
//             AddWord("OUNCE", index++);
//             AddWord("OUTDO", index++);
//             AddWord("OUTER", index++);
//             AddWord("OUTGO", index++);
//             AddWord("OVARY", index++);
//             AddWord("OVATE", index++);
//             AddWord("OVERT", index++);
//             AddWord("OVINE", index++);
//             AddWord("OVOID", index++);
//             AddWord("OWING", index++);
//             AddWord("OWNER", index++);
//             AddWord("OXIDE", index++);
//             AddWord("OZONE", index++);
//
//             pIndex = index;
//
//             AddWord("PADDY", index++);
//             AddWord("PAGAN", index++);
//             AddWord("PAINT", index++);
//             AddWord("PALER", index++);
//             AddWord("PALSY", index++);
//             AddWord("PANEL", index++);
//             AddWord("PANIC", index++);
//             AddWord("PANSY", index++);
//             AddWord("PAPAL", index++);
//             AddWord("PAPER", index++);
//             AddWord("PARER", index++);
//             AddWord("PARKA", index++);
//             AddWord("PARRY", index++);
//             AddWord("PARSE", index++);
//             AddWord("PARTY", index++);
//             AddWord("PASTA", index++);
//             AddWord("PASTE", index++);
//             AddWord("PASTY", index++);
//             AddWord("PATCH", index++);
//             AddWord("PATIO", index++);
//             AddWord("PATSY", index++);
//             AddWord("PATTY", index++);
//             AddWord("PAUSE", index++);
//             AddWord("PAYEE", index++);
//             AddWord("PAYER", index++);
//             AddWord("PEACE", index++);
//             AddWord("PEACH", index++);
//             AddWord("PEARL", index++);
//             AddWord("PECAN", index++);
//             AddWord("PEDAL", index++);
//             AddWord("PENAL", index++);
//             AddWord("PENCE", index++);
//             AddWord("PENNE", index++);
//             AddWord("PENNY", index++);
//             AddWord("PERCH", index++);
//             AddWord("PERIL", index++);
//             AddWord("PERKY", index++);
//             AddWord("PESKY", index++);
//             AddWord("PESTO", index++);
//             AddWord("PETAL", index++);
//             AddWord("PETTY", index++);
//             AddWord("PHASE", index++);
//             AddWord("PHONE", index++);
//             AddWord("PHONY", index++);
//             AddWord("PHOTO", index++);
//             AddWord("PIANO", index++);
//             AddWord("PICKY", index++);
//             AddWord("PIECE", index++);
//             AddWord("PIETY", index++);
//             AddWord("PIGGY", index++);
//             AddWord("PILOT", index++);
//             AddWord("PINCH", index++);
//             AddWord("PINEY", index++);
//             AddWord("PINKY", index++);
//             AddWord("PINTO", index++);
//             AddWord("PIPER", index++);
//             AddWord("PIQUE", index++);
//             AddWord("PITCH", index++);
//             AddWord("PITHY", index++);
//             AddWord("PIVOT", index++);
//             AddWord("PIXEL", index++);
//             AddWord("PIXIE", index++);
//             AddWord("PIZZA", index++);
//             AddWord("PLACE", index++);
//             AddWord("PLAID", index++);
//             AddWord("PLAIN", index++);
//             AddWord("PLAIT", index++);
//             AddWord("PLANE", index++);
//             AddWord("PLANK", index++);
//             AddWord("PLANT", index++);
//             AddWord("PLATE", index++);
//             AddWord("PLAZA", index++);
//             AddWord("PLEAD", index++);
//             AddWord("PLEAT", index++);
//             AddWord("PLIED", index++);
//             AddWord("PLIER", index++);
//             AddWord("PLUCK", index++);
//             AddWord("PLUMB", index++);
//             AddWord("PLUME", index++);
//             AddWord("PLUMP", index++);
//             AddWord("PLUNK", index++);
//             AddWord("PLUSH", index++);
//             AddWord("POESY", index++);
//             AddWord("POINT", index++);
//             AddWord("POISE", index++);
//             AddWord("POKER", index++);
//             AddWord("POLAR", index++);
//             AddWord("POLKA", index++);
//             AddWord("POLYP", index++);
//             AddWord("POOCH", index++);
//             AddWord("POPPY", index++);
//             AddWord("PORCH", index++);
//             AddWord("POSER", index++);
//             AddWord("POSIT", index++);
//             AddWord("POSSE", index++);
//             AddWord("POUCH", index++);
//             AddWord("POUND", index++);
//             AddWord("POUTY", index++);
//             AddWord("POWER", index++);
//             AddWord("PRANK", index++);
//             AddWord("PRAWN", index++);
//             AddWord("PREEN", index++);
//             AddWord("PRESS", index++);
//             AddWord("PRICE", index++);
//             AddWord("PRICK", index++);
//             AddWord("PRIDE", index++);
//             AddWord("PRIED", index++);
//             AddWord("PRIME", index++);
//             AddWord("PRIMO", index++);
//             AddWord("PRINT", index++);
//             AddWord("PRIOR", index++);
//             AddWord("PRISM", index++);
//             AddWord("PRIVY", index++);
//             AddWord("PRIZE", index++);
//             AddWord("PROBE", index++);
//             AddWord("PRONE", index++);
//             AddWord("PRONG", index++);
//             AddWord("PROOF", index++);
//             AddWord("PROSE", index++);
//             AddWord("PROUD", index++);
//             AddWord("PROVE", index++);
//             AddWord("PROWL", index++);
//             AddWord("PROXY", index++);
//             AddWord("PRUDE", index++);
//             AddWord("PRUNE", index++);
//             AddWord("PSALM", index++);
//             AddWord("PUBIC", index++);
//             AddWord("PUDGY", index++);
//             AddWord("PUFFY", index++);
//             AddWord("PULPY", index++);
//             AddWord("PULSE", index++);
//             AddWord("PUNCH", index++);
//             AddWord("PUPIL", index++);
//             AddWord("PUPPY", index++);
//             AddWord("PUREE", index++);
//             AddWord("PURER", index++);
//             AddWord("PURGE", index++);
//             AddWord("PURSE", index++);
//             AddWord("PUSHY", index++);
//             AddWord("PUTTY", index++);
//             AddWord("PYGMY", index++);
//
//             qIndex = index;
//
//             AddWord("QUACK", index++);
//             AddWord("QUAIL", index++);
//             AddWord("QUAKE", index++);
//             AddWord("QUALM", index++);
//             AddWord("QUARK", index++);
//             AddWord("QUART", index++);
//             AddWord("QUASH", index++);
//             AddWord("QUASI", index++);
//             AddWord("QUEEN", index++);
//             AddWord("QUEER", index++);
//             AddWord("QUELL", index++);
//             AddWord("QUERY", index++);
//             AddWord("QUEST", index++);
//             AddWord("QUEUE", index++);
//             AddWord("QUICK", index++);
//             AddWord("QUIET", index++);
//             AddWord("QUILL", index++);
//             AddWord("QUILT", index++);
//             AddWord("QUIRK", index++);
//             AddWord("QUITE", index++);
//             AddWord("QUOTA", index++);
//             AddWord("QUOTE", index++);
//             AddWord("QUOTH", index++);
//
//             rIndex = index;
//
//             AddWord("RABBI", index++);
//             AddWord("RABID", index++);
//             AddWord("RACER", index++);
//             AddWord("RADAR", index++);
//             AddWord("RADII", index++);
//             AddWord("RADIO", index++);
//             AddWord("RAINY", index++);
//             AddWord("RAISE", index++);
//             AddWord("RAJAH", index++);
//             AddWord("RALLY", index++);
//             AddWord("RALPH", index++);
//             AddWord("RAMEN", index++);
//             AddWord("RANCH", index++);
//             AddWord("RANDY", index++);
//             AddWord("RANGE", index++);
//             AddWord("RAPID", index++);
//             AddWord("RARER", index++);
//             AddWord("RASPY", index++);
//             AddWord("RATIO", index++);
//             AddWord("RATTY", index++);
//             AddWord("RAVEN", index++);
//             AddWord("RAYON", index++);
//             AddWord("RAZOR", index++);
//             AddWord("REACH", index++);
//             AddWord("REACT", index++);
//             AddWord("READY", index++);
//             AddWord("REALM", index++);
//             AddWord("REARM", index++);
//             AddWord("REBAR", index++);
//             AddWord("REBEL", index++);
//             AddWord("REBUS", index++);
//             AddWord("REBUT", index++);
//             AddWord("RECAP", index++);
//             AddWord("RECUR", index++);
//             AddWord("RECUT", index++);
//             AddWord("REEDY", index++);
//             AddWord("REFER", index++);
//             AddWord("REFIT", index++);
//             AddWord("REGAL", index++);
//             AddWord("REHAB", index++);
//             AddWord("REIGN", index++);
//             AddWord("RELAX", index++);
//             AddWord("RELAY", index++);
//             AddWord("RELIC", index++);
//             AddWord("REMIT", index++);
//             AddWord("RENAL", index++);
//             AddWord("RENEW", index++);
//             AddWord("REPAY", index++);
//             AddWord("REPEL", index++);
//             AddWord("REPLY", index++);
//             AddWord("RERUN", index++);
//             AddWord("RESET", index++);
//             AddWord("RESIN", index++);
//             AddWord("RETCH", index++);
//             AddWord("RETRO", index++);
//             AddWord("RETRY", index++);
//             AddWord("REUSE", index++);
//             AddWord("REVEL", index++);
//             AddWord("REVUE", index++);
//             AddWord("RHINO", index++);
//             AddWord("RHYME", index++);
//             AddWord("RIDER", index++);
//             AddWord("RIDGE", index++);
//             AddWord("RIFLE", index++);
//             AddWord("RIGHT", index++);
//             AddWord("RIGID", index++);
//             AddWord("RIGOR", index++);
//             AddWord("RINSE", index++);
//             AddWord("RIPEN", index++);
//             AddWord("RIPER", index++);
//             AddWord("RISEN", index++);
//             AddWord("RISER", index++);
//             AddWord("RISKY", index++);
//             AddWord("RIVAL", index++);
//             AddWord("RIVER", index++);
//             AddWord("RIVET", index++);
//             AddWord("ROACH", index++);
//             AddWord("ROAST", index++);
//             AddWord("ROBIN", index++);
//             AddWord("ROBOT", index++);
//             AddWord("ROCKY", index++);
//             AddWord("RODEO", index++);
//             AddWord("ROGER", index++);
//             AddWord("ROGUE", index++);
//             AddWord("ROOMY", index++);
//             AddWord("ROOST", index++);
//             AddWord("ROTOR", index++);
//             AddWord("ROUGE", index++);
//             AddWord("ROUGH", index++);
//             AddWord("ROUND", index++);
//             AddWord("ROUSE", index++);
//             AddWord("ROUTE", index++);
//             AddWord("ROVER", index++);
//             AddWord("ROWDY", index++);
//             AddWord("ROWER", index++);
//             AddWord("ROYAL", index++);
//             AddWord("RUDDY", index++);
//             AddWord("RUDER", index++);
//             AddWord("RUGBY", index++);
//             AddWord("RULER", index++);
//             AddWord("RUMBA", index++);
//             AddWord("RUMOR", index++);
//             AddWord("RUPEE", index++);
//             AddWord("RURAL", index++);
//             AddWord("RUSTY", index++);
//
//             sIndex = index;
//
//             AddWord("SADLY", index++);
//             AddWord("SAFER", index++);
//             AddWord("SAINT", index++);
//             AddWord("SALAD", index++);
//             AddWord("SALLY", index++);
//             AddWord("SALON", index++);
//             AddWord("SALSA", index++);
//             AddWord("SALTY", index++);
//             AddWord("SALVE", index++);
//             AddWord("SALVO", index++);
//             AddWord("SANDY", index++);
//             AddWord("SANER", index++);
//             AddWord("SAPPY", index++);
//             AddWord("SASSY", index++);
//             AddWord("SATIN", index++);
//             AddWord("SATYR", index++);
//             AddWord("SAUCE", index++);
//             AddWord("SAUCY", index++);
//             AddWord("SAUNA", index++);
//             AddWord("SAUTE", index++);
//             AddWord("SAVOR", index++);
//             AddWord("SAVOY", index++);
//             AddWord("SAVVY", index++);
//             AddWord("SCALD", index++);
//             AddWord("SCALE", index++);
//             AddWord("SCALP", index++);
//             AddWord("SCALY", index++);
//             AddWord("SCAMP", index++);
//             AddWord("SCANT", index++);
//             AddWord("SCARE", index++);
//             AddWord("SCARF", index++);
//             AddWord("SCARY", index++);
//             AddWord("SCENE", index++);
//             AddWord("SCENT", index++);
//             AddWord("SCION", index++);
//             AddWord("SCOFF", index++);
//             AddWord("SCOLD", index++);
//             AddWord("SCONE", index++);
//             AddWord("SCOOP", index++);
//             AddWord("SCOPE", index++);
//             AddWord("SCORE", index++);
//             AddWord("SCORN", index++);
//             AddWord("SCOUR", index++);
//             AddWord("SCOUT", index++);
//             AddWord("SCOWL", index++);
//             AddWord("SCRAM", index++);
//             AddWord("SCRAP", index++);
//             AddWord("SCREE", index++);
//             AddWord("SCREW", index++);
//             AddWord("SCRUB", index++);
//             AddWord("SCRUM", index++);
//             AddWord("SCUBA", index++);
//             AddWord("SEDAN", index++);
//             AddWord("SEEDY", index++);
//             AddWord("SEGUE", index++);
//             AddWord("SEIZE", index++);
//             AddWord("SEMEN", index++);
//             AddWord("SENSE", index++);
//             AddWord("SEPIA", index++);
//             AddWord("SERIF", index++);
//             AddWord("SERUM", index++);
//             AddWord("SERVE", index++);
//             AddWord("SETUP", index++);
//             AddWord("SEVEN", index++);
//             AddWord("SEVER", index++);
//             AddWord("SEWER", index++);
//             AddWord("SHACK", index++);
//             AddWord("SHADE", index++);
//             AddWord("SHADY", index++);
//             AddWord("SHAFT", index++);
//             AddWord("SHAKE", index++);
//             AddWord("SHAKY", index++);
//             AddWord("SHALE", index++);
//             AddWord("SHALL", index++);
//             AddWord("SHALT", index++);
//             AddWord("SHAME", index++);
//             AddWord("SHANK", index++);
//             AddWord("SHAPE", index++);
//             AddWord("SHARD", index++);
//             AddWord("SHARE", index++);
//             AddWord("SHARK", index++);
//             AddWord("SHARP", index++);
//             AddWord("SHAVE", index++);
//             AddWord("SHAWL", index++);
//             AddWord("SHEAR", index++);
//             AddWord("SHEEN", index++);
//             AddWord("SHEEP", index++);
//             AddWord("SHEER", index++);
//             AddWord("SHEET", index++);
//             AddWord("SHEIK", index++);
//             AddWord("SHELF", index++);
//             AddWord("SHELL", index++);
//             AddWord("SHIED", index++);
//             AddWord("SHIFT", index++);
//             AddWord("SHINE", index++);
//             AddWord("SHINY", index++);
//             AddWord("SHIRE", index++);
//             AddWord("SHIRK", index++);
//             AddWord("SHIRT", index++);
//             AddWord("SHOAL", index++);
//             AddWord("SHOCK", index++);
//             AddWord("SHONE", index++);
//             AddWord("SHOOK", index++);
//             AddWord("SHOOT", index++);
//             AddWord("SHORE", index++);
//             AddWord("SHORN", index++);
//             AddWord("SHORT", index++);
//             AddWord("SHOUT", index++);
//             AddWord("SHOVE", index++);
//             AddWord("SHOWN", index++);
//             AddWord("SHOWY", index++);
//             AddWord("SHREW", index++);
//             AddWord("SHRUB", index++);
//             AddWord("SHRUG", index++);
//             AddWord("SHUCK", index++);
//             AddWord("SHUNT", index++);
//             AddWord("SHUSH", index++);
//             AddWord("SHYLY", index++);
//             AddWord("SIEGE", index++);
//             AddWord("SIEVE", index++);
//             AddWord("SIGHT", index++);
//             AddWord("SIGMA", index++);
//             AddWord("SILKY", index++);
//             AddWord("SILLY", index++);
//             AddWord("SINCE", index++);
//             AddWord("SINEW", index++);
//             AddWord("SINGE", index++);
//             AddWord("SIREN", index++);
//             AddWord("SISSY", index++);
//             AddWord("SIXTH", index++);
//             AddWord("SIXTY", index++);
//             AddWord("SKATE", index++);
//             AddWord("SKIER", index++);
//             AddWord("SKIFF", index++);
//             AddWord("SKILL", index++);
//             AddWord("SKIMP", index++);
//             AddWord("SKIRT", index++);
//             AddWord("SKULK", index++);
//             AddWord("SKULL", index++);
//             AddWord("SKUNK", index++);
//             AddWord("SLACK", index++);
//             AddWord("SLAIN", index++);
//             AddWord("SLANG", index++);
//             AddWord("SLANT", index++);
//             AddWord("SLASH", index++);
//             AddWord("SLATE", index++);
//             AddWord("SLEEK", index++);
//             AddWord("SLEEP", index++);
//             AddWord("SLEET", index++);
//             AddWord("SLEPT", index++);
//             AddWord("SLICE", index++);
//             AddWord("SLICK", index++);
//             AddWord("SLIDE", index++);
//             AddWord("SLIME", index++);
//             AddWord("SLIMY", index++);
//             AddWord("SLING", index++);
//             AddWord("SLINK", index++);
//             AddWord("SLOOP", index++);
//             AddWord("SLOPE", index++);
//             AddWord("SLOSH", index++);
//             AddWord("SLOTH", index++);
//             AddWord("SLUMP", index++);
//             AddWord("SLUNG", index++);
//             AddWord("SLUNK", index++);
//             AddWord("SLURP", index++);
//             AddWord("SLUSH", index++);
//             AddWord("SLYLY", index++);
//             AddWord("SMACK", index++);
//             AddWord("SMALL", index++);
//             AddWord("SMART", index++);
//             AddWord("SMASH", index++);
//             AddWord("SMEAR", index++);
//             AddWord("SMELL", index++);
//             AddWord("SMELT", index++);
//             AddWord("SMILE", index++);
//             AddWord("SMIRK", index++);
//             AddWord("SMITE", index++);
//             AddWord("SMITH", index++);
//             AddWord("SMOCK", index++);
//             AddWord("SMOKE", index++);
//             AddWord("SMOKY", index++);
//             AddWord("SMOTE", index++);
//             AddWord("SNACK", index++);
//             AddWord("SNAIL", index++);
//             AddWord("SNAKE", index++);
//             AddWord("SNAKY", index++);
//             AddWord("SNARE", index++);
//             AddWord("SNARL", index++);
//             AddWord("SNEAK", index++);
//             AddWord("SNEER", index++);
//             AddWord("SNIDE", index++);
//             AddWord("SNIFF", index++);
//             AddWord("SNIPE", index++);
//             AddWord("SNOOP", index++);
//             AddWord("SNORE", index++);
//             AddWord("SNORT", index++);
//             AddWord("SNOUT", index++);
//             AddWord("SNOWY", index++);
//             AddWord("SNUCK", index++);
//             AddWord("SNUFF", index++);
//             AddWord("SOAPY", index++);
//             AddWord("SOBER", index++);
//             AddWord("SOGGY", index++);
//             AddWord("SOLAR", index++);
//             AddWord("SOLID", index++);
//             AddWord("SOLVE", index++);
//             AddWord("SONAR", index++);
//             AddWord("SONIC", index++);
//             AddWord("SOOTH", index++);
//             AddWord("SOOTY", index++);
//             AddWord("SORRY", index++);
//             AddWord("SOUND", index++);
//             AddWord("SOUTH", index++);
//             AddWord("SOWER", index++);
//             AddWord("SPACE", index++);
//             AddWord("SPADE", index++);
//             AddWord("SPANK", index++);
//             AddWord("SPARE", index++);
//             AddWord("SPARK", index++);
//             AddWord("SPASM", index++);
//             AddWord("SPAWN", index++);
//             AddWord("SPEAK", index++);
//             AddWord("SPEAR", index++);
//             AddWord("SPECK", index++);
//             AddWord("SPEED", index++);
//             AddWord("SPELL", index++);
//             AddWord("SPELT", index++);
//             AddWord("SPEND", index++);
//             AddWord("SPENT", index++);
//             AddWord("SPERM", index++);
//             AddWord("SPICE", index++);
//             AddWord("SPICY", index++);
//             AddWord("SPIED", index++);
//             AddWord("SPIEL", index++);
//             AddWord("SPIKE", index++);
//             AddWord("SPIKY", index++);
//             AddWord("SPILL", index++);
//             AddWord("SPILT", index++);
//             AddWord("SPINE", index++);
//             AddWord("SPINY", index++);
//             AddWord("SPIRE", index++);
//             AddWord("SPITE", index++);
//             AddWord("SPLAT", index++);
//             AddWord("SPLIT", index++);
//             AddWord("SPOIL", index++);
//             AddWord("SPOKE", index++);
//             AddWord("SPOOF", index++);
//             AddWord("SPOOK", index++);
//             AddWord("SPOOL", index++);
//             AddWord("SPOON", index++);
//             AddWord("SPORE", index++);
//             AddWord("SPORT", index++);
//             AddWord("SPOUT", index++);
//             AddWord("SPRAY", index++);
//             AddWord("SPREE", index++);
//             AddWord("SPRIG", index++);
//             AddWord("SPUNK", index++);
//             AddWord("SPURN", index++);
//             AddWord("SPURT", index++);
//             AddWord("SQUAD", index++);
//             AddWord("SQUAT", index++);
//             AddWord("SQUIB", index++);
//             AddWord("STACK", index++);
//             AddWord("STAFF", index++);
//             AddWord("STAGE", index++);
//             AddWord("STAID", index++);
//             AddWord("STAIN", index++);
//             AddWord("STAIR", index++);
//             AddWord("STAKE", index++);
//             AddWord("STALE", index++);
//             AddWord("STALK", index++);
//             AddWord("STALL", index++);
//             AddWord("STAMP", index++);
//             AddWord("STAND", index++);
//             AddWord("STANK", index++);
//             AddWord("STARE", index++);
//             AddWord("STARK", index++);
//             AddWord("START", index++);
//             AddWord("STASH", index++);
//             AddWord("STATE", index++);
//             AddWord("STAVE", index++);
//             AddWord("STEAD", index++);
//             AddWord("STEAK", index++);
//             AddWord("STEAL", index++);
//             AddWord("STEAM", index++);
//             AddWord("STEED", index++);
//             AddWord("STEEL", index++);
//             AddWord("STEEP", index++);
//             AddWord("STEER", index++);
//             AddWord("STEIN", index++);
//             AddWord("STERN", index++);
//             AddWord("STICK", index++);
//             AddWord("STIFF", index++);
//             AddWord("STILL", index++);
//             AddWord("STILT", index++);
//             AddWord("STING", index++);
//             AddWord("STINK", index++);
//             AddWord("STINT", index++);
//             AddWord("STOCK", index++);
//             AddWord("STOIC", index++);
//             AddWord("STOKE", index++);
//             AddWord("STOLE", index++);
//             AddWord("STOMP", index++);
//             AddWord("STONE", index++);
//             AddWord("STONY", index++);
//             AddWord("STOOD", index++);
//             AddWord("STOOL", index++);
//             AddWord("STOOP", index++);
//             AddWord("STORE", index++);
//             AddWord("STORK", index++);
//             AddWord("STORM", index++);
//             AddWord("STORY", index++);
//             AddWord("STOUT", index++);
//             AddWord("STOVE", index++);
//             AddWord("STRAP", index++);
//             AddWord("STRAW", index++);
//             AddWord("STRAY", index++);
//             AddWord("STRIP", index++);
//             AddWord("STRUT", index++);
//             AddWord("STUCK", index++);
//             AddWord("STUDY", index++);
//             AddWord("STUFF", index++);
//             AddWord("STUMP", index++);
//             AddWord("STUNG", index++);
//             AddWord("STUNK", index++);
//             AddWord("STUNT", index++);
//             AddWord("STYLE", index++);
//             AddWord("SUAVE", index++);
//             AddWord("SUGAR", index++);
//             AddWord("SUING", index++);
//             AddWord("SUITE", index++);
//             AddWord("SULKY", index++);
//             AddWord("SULLY", index++);
//             AddWord("SUMAC", index++);
//             AddWord("SUNNY", index++);
//             AddWord("SUPER", index++);
//             AddWord("SURER", index++);
//             AddWord("SURGE", index++);
//             AddWord("SURLY", index++);
//             AddWord("SUSHI", index++);
//             AddWord("SWAMI", index++);
//             AddWord("SWAMP", index++);
//             AddWord("SWARM", index++);
//             AddWord("SWASH", index++);
//             AddWord("SWATH", index++);
//             AddWord("SWEAR", index++);
//             AddWord("SWEAT", index++);
//             AddWord("SWEEP", index++);
//             AddWord("SWEET", index++);
//             AddWord("SWELL", index++);
//             AddWord("SWEPT", index++);
//             AddWord("SWIFT", index++);
//             AddWord("SWILL", index++);
//             AddWord("SWINE", index++);
//             AddWord("SWING", index++);
//             AddWord("SWIRL", index++);
//             AddWord("SWISH", index++);
//             AddWord("SWOON", index++);
//             AddWord("SWOOP", index++);
//             AddWord("SWORD", index++);
//             AddWord("SWORE", index++);
//             AddWord("SWORN", index++);
//             AddWord("SWUNG", index++);
//             AddWord("SYNOD", index++);
//             AddWord("SYRUP", index++);
//
//             tIndex = index;
//
//             AddWord("TABBY", index++);
//             AddWord("TABLE", index++);
//             AddWord("TABOO", index++);
//             AddWord("TACIT", index++);
//             AddWord("TACKY", index++);
//             AddWord("TAFFY", index++);
//             AddWord("TAINT", index++);
//             AddWord("TAKEN", index++);
//             AddWord("TAKER", index++);
//             AddWord("TALLY", index++);
//             AddWord("TALON", index++);
//             AddWord("TAMER", index++);
//             AddWord("TANGO", index++);
//             AddWord("TANGY", index++);
//             AddWord("TAPER", index++);
//             AddWord("TAPIR", index++);
//             AddWord("TARDY", index++);
//             AddWord("TAROT", index++);
//             AddWord("TASTE", index++);
//             AddWord("TASTY", index++);
//             AddWord("TATTY", index++);
//             AddWord("TAUNT", index++);
//             AddWord("TAWNY", index++);
//             AddWord("TEACH", index++);
//             AddWord("TEARY", index++);
//             AddWord("TEASE", index++);
//             AddWord("TEDDY", index++);
//             AddWord("TEETH", index++);
//             AddWord("TEMPO", index++);
//             AddWord("TENET", index++);
//             AddWord("TENOR", index++);
//             AddWord("TENSE", index++);
//             AddWord("TENTH", index++);
//             AddWord("TEPEE", index++);
//             AddWord("TEPID", index++);
//             AddWord("TERRA", index++);
//             AddWord("TERSE", index++);
//             AddWord("TESTY", index++);
//             AddWord("THANK", index++);
//             AddWord("THEFT", index++);
//             AddWord("THEIR", index++);
//             AddWord("THEME", index++);
//             AddWord("THERE", index++);
//             AddWord("THESE", index++);
//             AddWord("THETA", index++);
//             AddWord("THICK", index++);
//             AddWord("THIEF", index++);
//             AddWord("THIGH", index++);
//             AddWord("THING", index++);
//             AddWord("THINK", index++);
//             AddWord("THIRD", index++);
//             AddWord("THONG", index++);
//             AddWord("THORN", index++);
//             AddWord("THOSE", index++);
//             AddWord("THREE", index++);
//             AddWord("THREW", index++);
//             AddWord("THROB", index++);
//             AddWord("THROW", index++);
//             AddWord("THRUM", index++);
//             AddWord("THUMB", index++);
//             AddWord("THUMP", index++);
//             AddWord("THYME", index++);
//             AddWord("TIARA", index++);
//             AddWord("TIBIA", index++);
//             AddWord("TIDAL", index++);
//             AddWord("TIGER", index++);
//             AddWord("TIGHT", index++);
//             AddWord("TILDE", index++);
//             AddWord("TIMER", index++);
//             AddWord("TIMID", index++);
//             AddWord("TIPSY", index++);
//             AddWord("TITAN", index++);
//             AddWord("TITHE", index++);
//             AddWord("TITLE", index++);
//             AddWord("TOAST", index++);
//             AddWord("TODAY", index++);
//             AddWord("TODDY", index++);
//             AddWord("TOKEN", index++);
//             AddWord("TONAL", index++);
//             AddWord("TONGA", index++);
//             AddWord("TONIC", index++);
//             AddWord("TOOTH", index++);
//             AddWord("TOPAZ", index++);
//             AddWord("TOPIC", index++);
//             AddWord("TORCH", index++);
//             AddWord("TORSO", index++);
//             AddWord("TORUS", index++);
//             AddWord("TOTAL", index++);
//             AddWord("TOTEM", index++);
//             AddWord("TOUCH", index++);
//             AddWord("TOUGH", index++);
//             AddWord("TOWEL", index++);
//             AddWord("TOWER", index++);
//             AddWord("TOXIC", index++);
//             AddWord("TOXIN", index++);
//             AddWord("TRACE", index++);
//             AddWord("TRACK", index++);
//             AddWord("TRACT", index++);
//             AddWord("TRADE", index++);
//             AddWord("TRAIL", index++);
//             AddWord("TRAIN", index++);
//             AddWord("TRAIT", index++);
//             AddWord("TRAMP", index++);
//             AddWord("TRASH", index++);
//             AddWord("TRAWL", index++);
//             AddWord("TREAD", index++);
//             AddWord("TREAT", index++);
//             AddWord("TREND", index++);
//             AddWord("TRIAD", index++);
//             AddWord("TRIAL", index++);
//             AddWord("TRIBE", index++);
//             AddWord("TRICE", index++);
//             AddWord("TRICK", index++);
//             AddWord("TRIED", index++);
//             AddWord("TRIPE", index++);
//             AddWord("TRITE", index++);
//             AddWord("TROLL", index++);
//             AddWord("TROOP", index++);
//             AddWord("TROPE", index++);
//             AddWord("TROUT", index++);
//             AddWord("TROVE", index++);
//             AddWord("TRUCE", index++);
//             AddWord("TRUCK", index++);
//             AddWord("TRUER", index++);
//             AddWord("TRULY", index++);
//             AddWord("TRUMP", index++);
//             AddWord("TRUNK", index++);
//             AddWord("TRUSS", index++);
//             AddWord("TRUST", index++);
//             AddWord("TRUTH", index++);
//             AddWord("TRYST", index++);
//             AddWord("TUBAL", index++);
//             AddWord("TUBER", index++);
//             AddWord("TULIP", index++);
//             AddWord("TULLE", index++);
//             AddWord("TUMOR", index++);
//             AddWord("TUNIC", index++);
//             AddWord("TURBO", index++);
//             AddWord("TUTOR", index++);
//             AddWord("TWANG", index++);
//             AddWord("TWEAK", index++);
//             AddWord("TWEED", index++);
//             AddWord("TWEET", index++);
//             AddWord("TWICE", index++);
//             AddWord("TWINE", index++);
//             AddWord("TWIRL", index++);
//             AddWord("TWIST", index++);
//             AddWord("TWIXT", index++);
//             AddWord("TYING", index++);
//
//             uIndex = index;
//
//             AddWord("UDDER", index++);
//             AddWord("ULCER", index++);
//             AddWord("ULTRA", index++);
//             AddWord("UMBRA", index++);
//             AddWord("UNCLE", index++);
//             AddWord("UNCUT", index++);
//             AddWord("UNDER", index++);
//             AddWord("UNDID", index++);
//             AddWord("UNDUE", index++);
//             AddWord("UNFED", index++);
//             AddWord("UNFIT", index++);
//             AddWord("UNIFY", index++);
//             AddWord("UNION", index++);
//             AddWord("UNITE", index++);
//             AddWord("UNITY", index++);
//             AddWord("UNLIT", index++);
//             AddWord("UNMET", index++);
//             AddWord("UNSET", index++);
//             AddWord("UNTIE", index++);
//             AddWord("UNTIL", index++);
//             AddWord("UNWED", index++);
//             AddWord("UNZIP", index++);
//             AddWord("UPPER", index++);
//             AddWord("UPSET", index++);
//             AddWord("URBAN", index++);
//             AddWord("URINE", index++);
//             AddWord("USAGE", index++);
//             AddWord("USHER", index++);
//             AddWord("USING", index++);
//             AddWord("USUAL", index++);
//             AddWord("USURP", index++);
//             AddWord("UTILE", index++);
//             AddWord("UTTER", index++);
//
//             vIndex = index;
//
//             AddWord("VAGUE", index++);
//             AddWord("VALET", index++);
//             AddWord("VALID", index++);
//             AddWord("VALOR", index++);
//             AddWord("VALUE", index++);
//             AddWord("VALVE", index++);
//             AddWord("VAPID", index++);
//             AddWord("VAPOR", index++);
//             AddWord("VAULT", index++);
//             AddWord("VAUNT", index++);
//             AddWord("VEGAN", index++);
//             AddWord("VENOM", index++);
//             AddWord("VENUE", index++);
//             AddWord("VERGE", index++);
//             AddWord("VERSE", index++);
//             AddWord("VERSO", index++);
//             AddWord("VERVE", index++);
//             AddWord("VICAR", index++);
//             AddWord("VIDEO", index++);
//             AddWord("VIGIL", index++);
//             AddWord("VIGOR", index++);
//             AddWord("VILLA", index++);
//             AddWord("VINYL", index++);
//             AddWord("VIOLA", index++);
//             AddWord("VIPER", index++);
//             AddWord("VIRAL", index++);
//             AddWord("VIRUS", index++);
//             AddWord("VISIT", index++);
//             AddWord("VISOR", index++);
//             AddWord("VISTA", index++);
//             AddWord("VITAL", index++);
//             AddWord("VIVID", index++);
//             AddWord("VIXEN", index++);
//             AddWord("VOCAL", index++);
//             AddWord("VODKA", index++);
//             AddWord("VOGUE", index++);
//             AddWord("VOICE", index++);
//             AddWord("VOILA", index++);
//             AddWord("VOMIT", index++);
//             AddWord("VOTER", index++);
//             AddWord("VOUCH", index++);
//             AddWord("VOWEL", index++);
//             AddWord("VYING", index++);
//
//             wIndex = index;
//
//             AddWord("WACKY", index++);
//             AddWord("WAFER", index++);
//             AddWord("WAGER", index++);
//             AddWord("WAGON", index++);
//             AddWord("WAIST", index++);
//             AddWord("WAIVE", index++);
//             AddWord("WALTZ", index++);
//             AddWord("WARTY", index++);
//             AddWord("WASTE", index++);
//             AddWord("WATCH", index++);
//             AddWord("WATER", index++);
//             AddWord("WAVER", index++);
//             AddWord("WAXEN", index++);
//             AddWord("WEARY", index++);
//             AddWord("WEAVE", index++);
//             AddWord("WEDGE", index++);
//             AddWord("WEEDY", index++);
//             AddWord("WEIGH", index++);
//             AddWord("WEIRD", index++);
//             AddWord("WELCH", index++);
//             AddWord("WELSH", index++);
//             AddWord("WHACK", index++);
//             AddWord("WHALE", index++);
//             AddWord("WHARF", index++);
//             AddWord("WHEAT", index++);
//             AddWord("WHEEL", index++);
//             AddWord("WHELP", index++);
//             AddWord("WHERE", index++);
//             AddWord("WHICH", index++);
//             AddWord("WHIFF", index++);
//             AddWord("WHILE", index++);
//             AddWord("WHINE", index++);
//             AddWord("WHINY", index++);
//             AddWord("WHIRL", index++);
//             AddWord("WHISK", index++);
//             AddWord("WHITE", index++);
//             AddWord("WHOLE", index++);
//             AddWord("WHOOP", index++);
//             AddWord("WHOSE", index++);
//             AddWord("WIDEN", index++);
//             AddWord("WIDER", index++);
//             AddWord("WIDOW", index++);
//             AddWord("WIDTH", index++);
//             AddWord("WIELD", index++);
//             AddWord("WIGHT", index++);
//             AddWord("WILLY", index++);
//             AddWord("WIMPY", index++);
//             AddWord("WINCE", index++);
//             AddWord("WINCH", index++);
//             AddWord("WINDY", index++);
//             AddWord("WISER", index++);
//             AddWord("WISPY", index++);
//             AddWord("WITCH", index++);
//             AddWord("WITTY", index++);
//             AddWord("WOKEN", index++);
//             AddWord("WOMAN", index++);
//             AddWord("WOMEN", index++);
//             AddWord("WOODY", index++);
//             AddWord("WOOER", index++);
//             AddWord("WOOLY", index++);
//             AddWord("WOOZY", index++);
//             AddWord("WORDY", index++);
//             AddWord("WORLD", index++);
//             AddWord("WORRY", index++);
//             AddWord("WORSE", index++);
//             AddWord("WORST", index++);
//             AddWord("WORTH", index++);
//             AddWord("WOULD", index++);
//             AddWord("WOUND", index++);
//             AddWord("WOVEN", index++);
//             AddWord("WRACK", index++);
//             AddWord("WRATH", index++);
//             AddWord("WREAK", index++);
//             AddWord("WRECK", index++);
//             AddWord("WREST", index++);
//             AddWord("WRING", index++);
//             AddWord("WRIST", index++);
//             AddWord("WRITE", index++);
//             AddWord("WRONG", index++);
//             AddWord("WROTE", index++);
//             AddWord("WRUNG", index++);
//             AddWord("WRYLY", index++);
//
//             yIndex = index;
//
//             AddWord("YACHT", index++);
//             AddWord("YEARN", index++);
//             AddWord("YEAST", index++);
//             AddWord("YIELD", index++);
//             AddWord("YOUNG", index++);
//             AddWord("YOUTH", index++);
//
//             zIndex = index;
//
//             AddWord("ZEBRA", index++);
//             AddWord("ZESTY", index++);
//             AddWord("ZONAL", index++);
//         }
//
//
//
//         private void AddWord(string valueStr, int index)
//         {
//             WordleWords wordlWord = new WordleWords();
//             string word = valueStr.ToUpper();
//
//             word = word.Trim();
//
//             wordlWord.word = word;
//             wordlWord.firstLetter = word.Substring(0,1);
//             wordlWord.secondLetter = word.Substring(1, 1);
//             wordlWord.thirdLetter = word.Substring(2,1);
//             wordlWord.forthLetter = word.Substring(3,1);
//             wordlWord.fifthLetter = word.Substring(4, 1);
//             wordlWord.wordIndex = index;
//
//             allWords.Add(wordlWord);
//         }
//     }
//
