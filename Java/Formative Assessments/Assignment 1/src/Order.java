
import java.util.ArrayList;
import java.util.List;

public class Order {

    private Customer customer;
    private List<Book> books;

    public Order(Customer c) {
        customer = c;
        books = new ArrayList<Book>();
    }

    public void addBook(Book book) {
        books.add(book);
    }

    public void setCustomer(Customer c) {
        customer = c;
    }

    public Customer getCustomer() {
        return customer;
    }

    public List<Book> getBooks() {
        return books;
    }
}
