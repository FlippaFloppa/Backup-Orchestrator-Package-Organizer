using System;

public class User {

private String username;
private String password;

public User(String username, String password) {
    this.username = username;
    this.password = password;
}

    public String getusername() {
        return username;
    }
    public String getpassword() {
        return password;
    }
    //equals 
    
    public override String ToString() {
        return username + " " + password;
    }
}