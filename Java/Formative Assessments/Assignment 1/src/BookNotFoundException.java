
public class BookNotFoundException extends Exception{
    public BookNotFoundException(String title)
    {
        super("Error: Book with title '" + title + "' not found.");
    }
}
