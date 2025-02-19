// class Word {
//     - String _word "The actual word text" (Private)
//     + Word(String word) "Constructor to initialize a word" (Public)
//     + String Display(Bool) "If True, displays _word; if False, displays '_' * length of _word" (Public)
// }

class Word(string word)
{
    private readonly string _word = word;

    public string Display(bool display)     // Display method
    {
        if (display)
        {
            return _word + ' ';    // Return the word with a space
        }
        else
        {
            return new string('_', _word.Length) + ' ';   // Return a string of underscores with a space
        }
    }
}