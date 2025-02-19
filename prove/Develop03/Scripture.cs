// class Scripture {
//     - ScriptureRef _reference "Is the Scripture Reference" (Private)
//     - List<List<Word>> _content "1st list is the verses, 2nd list is the words" (Private)
//     - List<Bool> _displayedIndex "Tracks displayed words" (Private)
//     + Scripture(String book, Int verse, String content) "Parses content and sets a reference and content" (Public)
//     + Scripture(String book, Int startVerse, Int endVerse, String content) "Handles multiple verses" (Public)
//     + void Display() "Displays the verse by looping through the Word class" (Private)
//     + void ChangeDisplayedWords(Bool direction) "Randomly sets a value in _displayedIndex to True or False" (Private)
//     + void MemorizeLoop(Bool) "Calls ChangeDisplayedWords then Display()" (Public)
// }

public class Scripture
{
    private ScriptureRef _reference;
    private List<List<Word>> _content;
    private List<bool> _displayedIndex;

    public Scripture(string book, int chapter, int verse, string content)
    {
        _reference = new ScriptureRef(book, chapter, verse);
        _content = new List<List<Word>>();
        _displayedIndex = new List<bool>();

        string[] verses = content.Split("~|~");
        foreach (string verseContent in verses)
        {
            List<Word> words = new List<Word>();
            string[] wordsArray = verseContent.Split(' ');
            foreach (string word in wordsArray)
            {
                words.Add(new Word(word));
                _displayedIndex.Add(true);
            }
            _content.Add(words);
        }
    }

    public Scripture(string book, int chapter, int startVerse, int endVerse, string content)
    {
        _reference = new ScriptureRef(book, chapter, startVerse, endVerse);
        _content = new List<List<Word>>();
        _displayedIndex = new List<bool>();



        string[] verses = content.Split("~|~");
        foreach (string verseContent in verses)
        {
            List<Word> words = new List<Word>();
            string[] wordsArray = verseContent.Split(' ');
            foreach (string word in wordsArray)
            {
                words.Add(new Word(word));
                _displayedIndex.Add(true);
            }
            _content.Add(words);
        }
    }

    public void Display()
    {
        int index = 0;
        int verseNum = _reference.ReturnStartVerse();
        foreach (List<Word> verse in _content)
        {
            Console.Write(verseNum + " ");
            foreach (Word word in verse)
            {
                Console.Write(word.Display(_displayedIndex[index]));
                index++;
            }
            Console.WriteLine();
            verseNum++;
        }
    }

    private bool ChangeDisplayedWords(bool direction)
    {
        Random random = new Random();
        int index = random.Next(0, _displayedIndex.Count);
        bool done = false;

        if (_displayedIndex[index] == direction)
        {
            done = true;
            for (int i = 0; i < _displayedIndex.Count; i++)
            {
                bool displayed = _displayedIndex[i];
                if (displayed != direction)
                {
                    ChangeDisplayedWords(direction);
                    break;
                }
            }
        }
        else
        {
            _displayedIndex[index] = direction;
        }

        done = _displayedIndex.All(d => d == false);

        return done;
    }

    public string ReturnRefrence()
    {
        return _reference.ReturnRefrence();
    }
    public void ResetDesplay()
    {
        for (int i = 0; i < _displayedIndex.Count; i++)
        {
            _displayedIndex[i] = true;
        }
    }

    public bool MemorizeLoop(bool direction)
    {
        bool done = ChangeDisplayedWords(direction);
        Display();
        return done;
    }
}
    