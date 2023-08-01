# Character Copier

The character copier is a simple class that reads characters from a source and copies them to a destination one character at a time.

![](../../_docs-common/images/sc/Copier-Kata.png)

When the method Copy is called on the copier then it should read characters from the source and copy them to the destination until the source returns a newline (‘\n’) or the the whole source has been read.

The exercise is to experiment with using various test doubles of the source and destination object, in order to test the copier logic. Try implementing the character copier using handwritten mocks and spies for the source and the destination. After writing your own ones, try to use some common libraries that you may already know for test doubles.
