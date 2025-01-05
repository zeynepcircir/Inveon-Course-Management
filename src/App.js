import React, { useState, useEffect, createContext, useContext } from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import AppNavbar from './components/Navbar/Navbar';
import Sidebar from './components/Sidebar/Sidebar';
import PrivateRoute from './components/PrivateRoute/PrivateRoute';
import HomePage from './pages/HomePage/HomePage';
import CourseDetailPage from './pages/CourseDetailPage/CourseDetailPage';
import LoginPage from './pages/LoginPage/LoginPage';
import RegisterPage from './pages/RegisterPage/RegisterPage';
import TeacherPage from './pages/TeacherPage/TeacherPage';
import DashboardPage from './pages/DashboardPage/DashboardPage';
import AddCoursePage from './pages/AddCoursePage/AddCoursePage';
import EditCoursePage from './pages/EditCoursePage/EditCoursePage';
import { CartProvider } from './components/Context/CartContex';
import PaymentPage from './pages/PaymentPage/PaymentPage';
import Footer from './components/Footer/Footer';
import AboutPage from './pages/AboutPage/AboutPage';
import CartPage from './pages/CartPages/CartPage';
import ProfilePage from './pages/ProfilePage/ProfilePage';

// Dark Mode Context
export const ThemeContext = createContext();

export const useTheme = () => useContext(ThemeContext);

function App() {
  const [darkMode, setDarkMode] = useState(() => {
    const savedTheme = localStorage.getItem('darkMode');
    return savedTheme ? JSON.parse(savedTheme) : false;
  });

  useEffect(() => {
    localStorage.setItem('darkMode', JSON.stringify(darkMode));
  }, [darkMode]);

  const toggleDarkMode = () => {
    setDarkMode((prevMode) => !prevMode);
  };

  return (
    <ThemeContext.Provider value={{ darkMode, toggleDarkMode }}>
      <div
        style={{
          backgroundColor: darkMode ? '#1e1e1e' : '#f8f9fa',
          color: darkMode ? '#ffffff' : '#000000',
          minHeight: '100vh',
          paddingTop: '50px',
        }}
      >
        <CartProvider>
          <Router>
            <Routes>
              {/* Sayfalar: Navbar, Sidebar ve Footer olmadan */}
              <Route path="/login" element={<LoginPage />} />
              <Route path="/register" element={<RegisterPage />} />

              {/* Diğer sayfalar: Navbar, Sidebar ve Footer ile */}

              <Route
                path="/"
                element={
                  <PrivateRoute>
                    <Layout>
                      <HomePage />
                    </Layout>
                  </PrivateRoute>
                }
              />

              <Route
                path="/course/:id"
                element={
                  <PrivateRoute>
                    <Layout>
                      <CourseDetailPage />
                    </Layout>
                  </PrivateRoute>
                }
              />

              <Route
                path="/course/:id"
                element={
                  <PrivateRoute>
                    <Layout>
                      <CourseDetailPage />
                    </Layout>
                  </PrivateRoute>
                }
              />

              <Route
                path="/about"
                element={
                  <PrivateRoute>
                    <Layout>
                      <AboutPage />
                    </Layout>
                  </PrivateRoute>
                }
              />

              <Route
                path="/profile"
                element={
                  <PrivateRoute>
                    <Layout>
                      <ProfilePage />
                    </Layout>
                  </PrivateRoute>
                }
              />

              <Route
                path="/dashboard"
                element={
                  <PrivateRoute allowedRoles={['Student']}>
                    <Layout>
                      <DashboardPage />
                    </Layout>
                  </PrivateRoute>
                }
              />

              <Route
                path="/payment"
                element={
                  <PrivateRoute allowedRoles={['Student']}>
                    <Layout>
                      <PaymentPage />
                    </Layout>
                  </PrivateRoute>
                }
              />

              <Route
                path="/cart"
                element={
                  <PrivateRoute allowedRoles={['Student']}>
                    <Layout>
                      <CartPage />
                    </Layout>
                  </PrivateRoute>
                }
              />

              <Route
                path="/teacher"
                element={
                  <PrivateRoute allowedRoles={['Instructor']}>
                    <Layout>
                      <TeacherPage />
                    </Layout>
                  </PrivateRoute>
                }
              />

              <Route
                path="/teacher/add"
                element={
                  <PrivateRoute allowedRoles={['Instructor']}>
                    <Layout>
                      <AddCoursePage />
                    </Layout>
                  </PrivateRoute>
                }
              />

              <Route
                path="/teacher/edit/:id"
                element={
                  <PrivateRoute allowedRoles={['Instructor']}>
                    <Layout>
                      <EditCoursePage />
                    </Layout>
                  </PrivateRoute>
                }
              />

            </Routes>
          </Router>
        </CartProvider>
      </div>
    </ThemeContext.Provider>
  );
}

// Layout bileşeni: Navbar, Sidebar ve Footer için ortak yapı
const Layout = ({ children }) => {
  const { darkMode } = useTheme();

  return (
    <div className="d-flex flex-column" style={{ minHeight: '100vh' }}>
      <AppNavbar />
      <div className="d-flex flex-grow-1">
        <div
          className={`border-end ${darkMode ? 'bg-dark text-light' : 'bg-light text-dark'
            }`}
          style={{ width: '250px' }}
        >
          <Sidebar />
        </div>
        <div className="flex-grow-1 p-4">{children}</div>
      </div>
      <Footer />
    </div>
  );
};

export default App;
