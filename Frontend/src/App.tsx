import React from 'react';
import './App.css';
import Search from "./components/search";

function App() {
    return (
        <div className="d-flex justify-content-center align-items-center flex-column">
            <p className="h3">
                Welcome to the store
            </p>

            <section className="d-flex flex-column justify-content-center align-items-center">
                <Search/>
            </section>
        </div>
    )
}

export default App;
