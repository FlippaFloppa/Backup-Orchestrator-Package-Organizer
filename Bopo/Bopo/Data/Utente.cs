using System;

public class Utente {

private String username;
private String password;

public Utente(String username, String password) {
    this.username = username;
    this.password = password;
}

    public String getUsername() {
        return username;
    }
    public String getPassword() {
        return password;
    }
    
    public override String ToString() {
        return username + " " + password;
    }
}