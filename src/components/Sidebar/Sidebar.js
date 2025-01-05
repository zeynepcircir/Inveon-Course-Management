import React, { useState, useEffect } from 'react';
import { Nav, NavItem, NavLink, Button, Collapse } from 'reactstrap';
import { FaBars, FaChalkboardTeacher, FaPlus, FaTachometerAlt } from 'react-icons/fa';
import { useTheme } from '../../App';
import './Sidebar.css';

const Sidebar = () => {
  const [isOpen, setIsOpen] = useState(true);
  const [isMobile, setIsMobile] = useState(window.innerWidth < 768);
  const { darkMode } = useTheme();
  const token = localStorage.getItem('token');
  const userRoles = token ? JSON.parse(atob(token.split('.')[1])).roles : [];

  useEffect(() => {
    const handleResize = () => {
      setIsMobile(window.innerWidth < 768);
      if (window.innerWidth >= 768) {
        setIsOpen(true);
      }
    };

    window.addEventListener('resize', handleResize);
    return () => window.removeEventListener('resize', handleResize);
  }, []);

  const toggleSidebar = () => {
    setIsOpen(!isOpen);
  };

  return (
    <div>
      {isMobile && (
        <Button
          className="d-md-none"
          color="primary"
          onClick={toggleSidebar}
          style={{
            position: 'fixed',
            top: '15px',
            left: '15px',
            zIndex: '1050',
            boxShadow: '0 2px 4px rgba(0, 0, 0, 0.2)',
          }}
        >
          <FaBars />
        </Button>
      )}

      <Collapse isOpen={isOpen} className="d-md-block">
        <div
          className="vh-100 p-3 shadow"
          style={{
            width: '250px',
            position: 'fixed',
            top: '20px',
            left: '0',
            background: darkMode ? '#343a40' : '#f8f9fa',
            color: darkMode ? '#f8f9fa' : '#333',
            zIndex: isMobile ? '1040' : '1',
            borderRight: `1px solid ${darkMode ? '#495057' : '#dee2e6'}`,
            transition: 'transform 0.3s ease-in-out',
            transform: isOpen || !isMobile ? 'translateX(0)' : 'translateX(-100%)',
            boxShadow: '2px 0 5px rgba(0, 0, 0, 0.1)',
          }}
        >
          <h4 className="text-center mb-4" style={{ fontSize: '1.5rem' }}>Menu</h4>
          <Nav vertical>
            <NavItem className="mb-4">
              <NavLink
                href="/"
                className="sidebar-link"
                style={{ color: darkMode ? '#ffffff' : '#333' }}
              >
                <FaTachometerAlt className="me-2" size={22} />
                <span style={{ fontSize: '1.2rem' }}>Browse</span>
              </NavLink>
            </NavItem>
            {userRoles.includes('Student') && (
              <NavItem className="mb-4">
                <NavLink
                  href="/dashboard"
                  className="sidebar-link"
                  style={{ color: darkMode ? '#ffffff' : '#333' }}
                >
                  <FaChalkboardTeacher className="me-2" size={22} />
                  <span style={{ fontSize: '1.2rem' }}>Dashboard</span>
                </NavLink>
              </NavItem>
            )}
            {userRoles.includes('Instructor') && (
              <NavItem className="mb-4">
                <NavLink
                  href="/teacher"
                  className="sidebar-link"
                  style={{ color: darkMode ? '#ffffff' : '#333' }}
                >
                  <FaPlus className="me-2" size={22} />
                  <span style={{ fontSize: '1.2rem' }}>Teacher Mode</span>
                </NavLink>
              </NavItem>
            )}
          </Nav>
        </div>
      </Collapse>
    </div>
  );
};

export default Sidebar;