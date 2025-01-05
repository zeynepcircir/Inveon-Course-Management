import React from 'react';
import { Navigate } from 'react-router-dom';

const PrivateRoute = ({ children, allowedRoles }) => {
    const token = localStorage.getItem('token');
    const userRoles = token ? JSON.parse(atob(token.split('.')[1])).roles : []; // JWT'den rolleri çözümleme

    if (!token) {
        return <Navigate to="/login" />;
    }

    if (allowedRoles && !allowedRoles.some((role) => userRoles.includes(role))) {
        return <Navigate to="/" />;
    }

    return children;
};

export default PrivateRoute;
