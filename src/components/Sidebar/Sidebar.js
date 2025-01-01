import React from 'react';
import { Nav, NavItem, NavLink } from 'reactstrap';
import { FaChalkboardTeacher, FaPlus, FaTachometerAlt } from 'react-icons/fa';
import './Sidebar.css';

const Sidebar = () => {
  return (
    <div className="sidebar bg-light shadow vh-100 d-flex flex-column p-3">
      <h4 className="text-center mb-4">Menu</h4>
      <Nav vertical>
        <NavItem className="mb-3">
          <NavLink href="/browse" className="d-flex align-items-center text-dark">
            <FaTachometerAlt className="me-2" size={20} />
            <span>Browse</span>
          </NavLink>
        </NavItem>
        <NavItem className="mb-3">
          <NavLink href="/dashboard" className="d-flex align-items-center text-dark">
            <FaChalkboardTeacher className="me-2" size={20} />
            <span>Dashboard</span>
          </NavLink>
        </NavItem>
        <NavItem className="mb-3">
          <NavLink href="/teacher" className="d-flex align-items-center text-dark">
            <FaPlus className="me-2" size={20} />
            <span>Teacher Mode</span>
          </NavLink>
        </NavItem>
      </Nav>
    </div>
  );
};

export default Sidebar;
