
public class Customer {

    private String name, email;

    public Customer() {
    }

    public Customer(String n, String e) {
        name = n;
        email = e;
    }

    public void setName(String n) {
        name = n;
    }

    public String getName() {
        return name;
    }

    public void setEmail(String e) {
        email = e;
    }

    public String getEmail() {
        return email;
    }
}
