// class ScriptureRef {
//     - String _book "Book name" (Private)
//     - Int _chapter "Chapter number" (Private)
//     - Int _startVerse "Starting verse number" (Private)
//     - Int _endVerse "Ending verse number" (Private)
//     + ScriptureRef(String book, Int chapter, Int startVerse) (Public)
//     + ScriptureRef(String book, Int chapter, Int startVerse, Int endVerse) (Public)
//     + String ReturnChapt() "Returns formatted book and chapter" (Public)
//     + List<Int> ReturnVerses() "Returns a list of verse numbers" (Public)
// }

class ScriptureRef
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public ScriptureRef(string book, int chapter, int startVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
    }

    public ScriptureRef(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string ReturnChapt()
    {
        return $"{_book} {_chapter}";
    }

    public int ReturnStartVerse()
    {
        return _startVerse;
    }

    public string ReturnRefrence()
    {
        if (_endVerse != 0)
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
    }
}