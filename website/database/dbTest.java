package dbConnectionTest;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
 
public class dbTest {
    public static void main(String[] args) {
        String databaseURL = "jdbc:mysql://[databaseLocation]/";
        String user = "root";
        String password = "[usePassword]";
        Connection conn = null;
        try {
            Class.forName("com.mysql.cj.jdbc.Driver");
            conn = DriverManager.getConnection(databaseURL, user, password);
            if (conn != null) {
                System.out.println("Connected to the database");
            }
        } catch (ClassNotFoundException ex) {
            System.out.println("Could not find database driver class");
            ex.printStackTrace();
        } catch (SQLException ex) {
            System.out.println("An error occurred. Maybe user/password is invalid");
            ex.printStackTrace();
        } finally {
            if (conn != null) {
                try {
                    conn.close();
                } catch (SQLException ex) {
                    ex.printStackTrace();
                }
            }
        }
    }
}
