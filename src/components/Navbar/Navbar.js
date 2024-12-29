import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { Navbar, Nav, NavItem, Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';
import './Navbar.css';

const AppNavbar = () => {
  const navigate = useNavigate();
  const [dropdownOpen, setDropdownOpen] = useState(false);
  const toggleDropdown = () => setDropdownOpen(!dropdownOpen);

  const isInstructor = true; // Geçici olarak true, backend ile kontrol edilecek
  const userName = "Alex"; // Örnek kullanıcı adı, backend'den alınacak

  const handleLogout = () => {
    alert('Logged out successfully!');
    navigate('/login'); // Çıkış yaptıktan sonra login sayfasına yönlendirme
  };

  return (
    <Navbar color="light" light expand="md" className="navbar">
      <Link to="/" className="navbar-brand">
        Course Management
      </Link>
      <Nav className="ml-auto" navbar>
        <NavItem>
          <Link to="/browse" className="nav-link">
            Browse
          </Link>
        </NavItem>
        <NavItem>
          <Link to="/dashboard" className="nav-link">
            Dashboard
          </Link>
        </NavItem>
        {isInstructor && (
          <NavItem>
            <Link to="/teacher" className="nav-link">
              Teacher Mode
            </Link>
          </NavItem>
        )}
        <Dropdown nav isOpen={dropdownOpen} toggle={toggleDropdown} className="user-profile">
          <DropdownToggle nav caret className="user-icon-toggle">
            <div className="user-icon">
              <span>{userName[0]}</span>
            </div>
          </DropdownToggle>
          <DropdownMenu right>
            <DropdownItem header>{userName}</DropdownItem>
            <DropdownItem divider />
            <DropdownItem onClick={handleLogout}>Logout</DropdownItem>
          </DropdownMenu>
        </Dropdown>
      </Nav>
    </Navbar>
  );
};

export default AppNavbar;
