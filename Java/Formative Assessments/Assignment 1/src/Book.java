
public class Book {

    private String title, author;
    private double price;

    public Book() {
    }

    public Book(String t, String a, double p) {
        title = t;
        author = a;
        price = p;
    }

    public void setTitle(String t) {
        title = t;
    }

    public String getTitle() {
        return title;
    }

    public void setAuthor(String a) {
        author = a;
    }

    public String getAuthor() {
        return author;
    }

    public void setPrice(double p) {
        price = p;
    }

    public double getPrice() {
        return price;
    }
}
