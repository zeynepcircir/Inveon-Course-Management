import React from 'react';
import { Nav, NavItem, NavLink } from 'reactstrap';
import { FaChalkboardTeacher, FaPlus, FaTachometerAlt } from 'react-icons/fa';
import { useTheme } from '../../App'; // Dark mode context
import './Sidebar.css';

const Sidebar = () => {
  const { darkMode } = useTheme(); // Dark mode durumunu al

  return (
    <div
      className={`sidebar vh-100 d-flex flex-column p-3 shadow ${
        darkMode ? 'bg-dark text-light' : 'bg-light text-dark'
      }`}
    >
      <h4 className="text-center mb-4">Menu</h4>
      <Nav vertical>
        <NavItem className="mb-3">
          <NavLink
            href="/browse"
            className={`d-flex align-items-center ${darkMode ? 'text-light' : 'text-dark'}`}
          >
            <FaTachometerAlt className="me-2" size={20} />
            <span>Browse</span>
          </NavLink>
        </NavItem>
        <NavItem className="mb-3">
          <NavLink
            href="/dashboard"
            className={`d-flex align-items-center ${darkMode ? 'text-light' : 'text-dark'}`}
          >
            <FaChalkboardTeacher className="me-2" size={20} />
            <span>Dashboard</span>
          </NavLink>
        </NavItem>
        <NavItem className="mb-3">
          <NavLink
            href="/teacher"
            className={`d-flex align-items-center ${darkMode ? 'text-light' : 'text-dark'}`}
          >
            <FaPlus className="me-2" size={20} />
            <span>Teacher Mode</span>
          </NavLink>
        </NavItem>
      </Nav>
    </div>
  );
};

export default Sidebar;
