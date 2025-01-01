import React from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { Navbar, Nav, NavItem } from 'reactstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faGraduationCap, faSignOutAlt, faShoppingCart } from '@fortawesome/free-solid-svg-icons';

const AppNavbar = () => {
  const navigate = useNavigate();
  const userName = "Alex"; // Örnek kullanıcı adı

  const handleLogout = () => {
    navigate('/login'); // Login sayfasına yönlendirme
  };

  const handleCartNavigate = () => {
    navigate('/cart'); // Sepete yönlendirme
  };

  return (
    <Navbar color="light" light expand="md" className="shadow-sm fixed-top px-3">
      <div className="container-fluid d-flex justify-content-between align-items-center">
        {/* Sol tarafta başlık ve ikon */}
        <div className="d-flex align-items-center">
          <FontAwesomeIcon icon={faGraduationCap} className="me-2 text-primary" size="lg" />
          <Link to="/" className="navbar-brand fw-bold mb-0">
            Course Management
          </Link>
        </div>

        <Nav className="d-flex align-items-center gap-4">
          {/* Sepet İkonu */}
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

          {/* Kullanıcı İkonu ve Logout */}
          <NavItem className="d-flex align-items-center">
            {/* Kullanıcı İkonu */}
            <div
              className="bg-primary text-white rounded-circle d-flex justify-content-center align-items-center"
              style={{ width: '40px', height: '40px', fontWeight: 'bold' }}
              title={userName}
            >
              {userName[0]}
            </div>

            {/* Logout İkonu */}
            <FontAwesomeIcon
              icon={faSignOutAlt}
              className="ms-3 text-secondary"
              size="lg"
              onClick={handleLogout}
              style={{ cursor: 'pointer' }}
              title="Logout"
            />
          </NavItem>
        </Nav>
      </div>
    </Navbar>
  );
};

export default AppNavbar;
