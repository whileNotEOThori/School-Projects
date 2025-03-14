
public class InvalidOrderException extends Exception {

    public InvalidOrderException() {
        super("Error processing order: Invalid order - Order must contain at least one book.");
    }
}
