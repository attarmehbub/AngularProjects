import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

// In a real app, you would have logic to check for a JWT token, user session, etc.
  private isAuthenticated = false;

  constructor() { }

  login(): void {
    // Implement your login logic, e.g., setting a token in local storage
    this.isAuthenticated = true;
  }

  logout(): void {
    // Implement your logout logic, e.g., clearing the token
    this.isAuthenticated = false;
  }

  isLoggedIn(): boolean {
    // Check if the user is authenticated
    return this.isAuthenticated;
  }
}
