
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

    public int findBook(String title) {
        if (inventory.isEmpty()) {
            return -1;
        }

        for (int i = 0, n = inventory.size(); i < n; i++) {
            if (inventory.get(i).getTitle() == title) {
                return i;
            }
        }

        return -1;
    }
}
