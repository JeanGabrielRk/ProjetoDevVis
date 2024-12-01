import React from 'react';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import ListaPlantas from './Componentes/ListaPlanta';
import CadastrarPlanta from './Componentes/CadastrarPlanta';
import ExcluirPlanta from './Componentes/ExcluirPlanta';
import BuscarPlanta from './Componentes/BuscarPlanta';

const App: React.FC = () => {
    return (
        <Router>
            <div>
                <h1>Eco Planta</h1>
                <nav>
                    <ul>
                        <li><Link to="/">Listar Plantas</Link></li>
                        <li><Link to="/cadastrar">Cadastrar Planta</Link></li>
                        <li><Link to="/excluir">Excluir Planta</Link></li>
                        <li><Link to="/buscar">Buscar Planta</Link></li>
                    </ul>
                </nav>
                <Routes>
                    <Route path="/" element={<ListaPlantas />} />
                    <Route path="/cadastrar" element={<CadastrarPlanta />} />
                    <Route path="/excluir" element={<ExcluirPlanta />} />
                    <Route path="/buscar" element={<BuscarPlanta />} />
                </Routes>
            </div>
        </Router>
    );
};

export default App;





