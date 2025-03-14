
import java.util.ArrayList;
import java.util.List;

public class Inventory {

    private List<Book> inventory;

    public Inventory() {
        inventory = new ArrayList<Book>();
    }

    public void addBook(Book book) {
        inventory.add(book);
    }

    public Book findBook(String title) throws BookNotFoundException {
        for (int i = 0, n = inventory.size(); i < n; i++) {
            if (inventory.get(i).getTitle() == title) {
                return inventory.get(i);
            }
        }
        throw new BookNotFoundException(title);
    }

    public List<Book> getInventory() {
        return inventory;
    }
}
