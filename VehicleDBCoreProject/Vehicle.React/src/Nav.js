import React from 'react';
import { Link } from 'react-router-dom';

class Nav extends React.Component {
    render() {
        return (
            <nav>
                <ul className="nav-links">
                    <Link style={{ color: "white"}} to="/" >
                        <li>Makers Mock</li>
                    </Link>
                    <Link style={{ color: "white" }} to="/ModelsMock">
                        <li>Models Mock</li>
                    </Link>
                    <Link style={{ color: "white" }} to="/MakersApi">
                        <li>Makers API</li>
                    </Link>
                    <Link style={{ color: "white" }} to="/ModelsApi">
                        <li>Models API</li>
                    </Link>
                    
                    
                    
                </ul>
            </nav>
            )
    }
}

export default Nav;