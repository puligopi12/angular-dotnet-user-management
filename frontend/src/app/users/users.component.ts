import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  users: any[] = [];
  selectedAll = false;

  user = {
    id: 0,
    name: '',
    contact: ''
  };

  isEditMode = false;

  constructor(private userService: UserService) {}

  ngOnInit() {
    this.loadUsers();
  }

  loadUsers() {
    this.userService.getUsers().subscribe({
      next: (data) => {
        this.users = data.map(u => ({ ...u, selected: false }));
        this.selectedAll = false;
      },
      error: () => {
        alert('Error loading users');
      }
    });
  }

  toggleSelectAll() {
    this.users.forEach(u => u.selected = this.selectedAll);
  }

  checkIfAllSelected() {
    this.selectedAll =
      this.users.length > 0 &&
      this.users.every(u => u.selected);
  }

  hasSelectedUsers(): boolean {
    return this.users.some(u => u.selected);
  }

  saveUser() {
    if (this.isEditMode) {
      this.userService.updateUser(this.user).subscribe(() => {
        this.resetForm();
        this.loadUsers();
      });
    } else {
      this.userService.addUser(this.user).subscribe(() => {
        this.resetForm();
        this.loadUsers();
      });
    }
  }

  editUser(u: any) {
    this.user = { ...u };
    this.isEditMode = true;
  }

  deleteUser(id: number) {
    if (!confirm('Are you sure you want to delete this user?')) return;

    this.userService.deleteUser(id).subscribe(() => {
      this.loadUsers();
      alert('User deleted successfully');
    });
  }

  deleteSelectedUsers() {
    const selectedUsers = this.users.filter(u => u.selected);

    if (selectedUsers.length === 0) {
      alert('Please select at least one user');
      return;
    }

    if (!confirm(`Are you sure you want to delete ${selectedUsers.length} users?`)) {
      return;
    }

    selectedUsers.forEach(u => {
      this.userService.deleteUser(u.id).subscribe(() => {
        this.loadUsers();
      });
    });
  }

  resetForm() {
    this.user = { id: 0, name: '', contact: '' };
    this.isEditMode = false;
  }
}
