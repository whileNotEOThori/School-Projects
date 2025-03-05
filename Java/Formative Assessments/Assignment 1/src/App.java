
public class App {

    public static void main(String[] args) throws Exception {
        // System.out.println("Hello, World!");
        bookTest();
    }

    private static void bookTest() {
        Book book1 = new Book();
        Book book2 = new Book("Java", "John Doe", 50);

        System.out.println("Book 1 using default constructor:");
        System.out.println("\tTitle: " + book1.getTitle());
        System.out.println("\tAuthor: " + book1.getAuthor());
        System.out.println("\tPrice: " + book1.getPrice());
        System.out.println();

        book1.setTitle("HTML");
        book1.setAuthor("Jane Doe");
        book1.setPrice(100.00);

        System.out.println("Book 2 using parameter constructor:");
        System.out.println("\tTitle: " + book2.getTitle());
        System.out.println("\tAuthor: " + book2.getAuthor());
        System.out.println("\tPrice: " + book2.getPrice());
        System.out.println();

        System.out.println("Book 1 after setters:");
        System.out.println("\tTitle: " + book1.getTitle());
        System.out.println("\tAuthor: " + book1.getAuthor());
        System.out.println("\tPrice: " + book1.getPrice());
        System.out.println();

    }
}
