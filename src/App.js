import React, { useState, useEffect, createContext, useContext } from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import AppNavbar from './components/Navbar/Navbar';
import Sidebar from './components/Sidebar/Sidebar';
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
    // LocalStorage'den dark mode durumunu al
    const savedTheme = localStorage.getItem('darkMode');
    return savedTheme ? JSON.parse(savedTheme) : false;
  });

  useEffect(() => {
    // Dark mode durumunu localStorage'e kaydet
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
        }}
      >
        <CartProvider>
          <Router>
            <div className="d-flex flex-column" style={{ minHeight: '100vh' }}>
              {/* Navbar */}
              <AppNavbar />
              
              <div className="d-flex flex-grow-1">
                {/* Sidebar */}
                <div
                  className={`border-end ${
                    darkMode ? 'bg-dark text-light' : 'bg-light text-dark'
                  }`}
                  style={{ width: '250px' }}
                >
                  <Sidebar />
                </div>
                
                {/* Main Content */}
                <div className="flex-grow-1 p-4">
                  <Routes>
                    <Route path="/" element={<HomePage />} />
                    <Route path="/course/:id" element={<CourseDetailPage />} />
                    <Route path="/login" element={<LoginPage />} />
                    <Route path="/browse" element={<HomePage />} />
                    <Route path="/register" element={<RegisterPage />} />
                    <Route path="/dashboard" element={<DashboardPage />} />
                    <Route path="/teacher" element={<TeacherPage />} />
                    <Route path="/teacher/add" element={<AddCoursePage />} />
                    <Route path="/teacher/edit/:id" element={<EditCoursePage />} />
                    <Route path="/payment" element={<PaymentPage />} />
                    <Route path="/about" element={<AboutPage />} />
                    <Route path="/cart" element={<CartPage />} />
                    <Route path="/profile" element={<ProfilePage/>} />
                  </Routes>
                  <Footer />
                </div>
              </div>
            </div>
          </Router>
        </CartProvider>
      </div>
    </ThemeContext.Provider>
  );
}

export default App;
