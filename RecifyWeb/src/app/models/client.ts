export class Client {
    id?: string;
    email: string;
    username: string;
    passwordHash: string;
    firstName: string;
    lastName?: string;

    constructor(
        email: string,
        username: string,
        passwordHash: string,
        firstName: string,
        lastName?: string,
        id?: string
    ) {
        this.email = email;
        this.username = username;
        this.passwordHash = passwordHash;
        this.firstName = firstName;
        this.lastName = lastName;
        this.id = id;
    }
}