import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import {
  Navbar,
  Nav,
  NavItem,
  Dropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
  NavbarToggler,
  Collapse,
} from 'reactstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {
  faGraduationCap,
  faSignOutAlt,
  faMoon,
  faSun,
  faUser,
  faShoppingCart,
} from '@fortawesome/free-solid-svg-icons';
import { useTheme } from '../../App';

const AppNavbar = () => {
  const navigate = useNavigate();
  const { darkMode, toggleDarkMode } = useTheme();
  const [dropdownOpen, setDropdownOpen] = useState(false);
  const [isOpen, setIsOpen] = useState(false); 
  const userName = 'Alex';

  const toggleDropdown = () => setDropdownOpen(!dropdownOpen);
  const toggleNavbar = () => setIsOpen(!isOpen); 

  const handleLogout = () => {
    navigate('/login');
  };

  const handleCartNavigate = () => {
    navigate('/cart');
  };

  const handleNavigate = (path) => {
    navigate(path);
  };

  return (
    <Navbar
      color={darkMode ? 'dark' : 'light'}
      light={!darkMode}
      dark={darkMode}
      expand="md"
      className="shadow-sm fixed-top px-3"
      style={{ minHeight: '60px' }} 
    >
      <div className="container-fluid d-flex justify-content-between align-items-center">
        <div className="d-flex align-items-center">
          <FontAwesomeIcon icon={faGraduationCap} className="me-2 text-primary" size="lg" />
          <Link to="/" className={`navbar-brand fw-bold mb-0 ${darkMode ? 'text-light' : 'text-dark'}`}>
            Course Management
          </Link>
        </div>

        <NavbarToggler onClick={toggleNavbar} className="d-md-none">
          <FontAwesomeIcon icon={faUser} />
        </NavbarToggler>

        <Collapse isOpen={isOpen} navbar>
          <Nav className="ms-auto d-flex align-items-center gap-3">
            <NavItem>
              <FontAwesomeIcon
                icon={faShoppingCart}
                className="text-secondary"
                size="lg"
                onClick={handleCartNavigate}
                style={{ cursor: 'pointer' }}
                title="View Cart"
              />
            </NavItem>

            <Dropdown nav isOpen={dropdownOpen} toggle={toggleDropdown}>
              <DropdownToggle nav caret className="d-flex align-items-center">
                <div
                  className="bg-primary text-white rounded-circle d-flex justify-content-center align-items-center me-2"
                  style={{ width: '40px', height: '40px', fontWeight: 'bold' }}
                  title={userName}
                >
                  {userName[0]}
                </div>
                <span className={darkMode ? 'text-light' : 'text-secondary'}>{userName}</span>
              </DropdownToggle>
              <DropdownMenu end>
                <DropdownItem onClick={() => handleNavigate('/profile')}>
                  <FontAwesomeIcon icon={faUser} className="me-2" />
                  Profile Settings
                </DropdownItem>
                <DropdownItem onClick={toggleDarkMode}>
                  <FontAwesomeIcon icon={darkMode ? faSun : faMoon} className="me-2" />
                  {darkMode ? 'Light Mode' : 'Dark Mode'}
                </DropdownItem>
                <DropdownItem divider />
                <DropdownItem onClick={handleLogout}>
                  <FontAwesomeIcon icon={faSignOutAlt} className="me-2" />
                  Logout
                </DropdownItem>
              </DropdownMenu>
            </Dropdown>
          </Nav>
        </Collapse>
      </div>
    </Navbar>
  );
};

export default AppNavbar;
