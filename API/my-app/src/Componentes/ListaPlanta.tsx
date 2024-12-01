import React, { useEffect, useState } from 'react';
import { Planta } from '../Interfaces/Planta';

const ListaPlantas: React.FC = () => {
    const [plantas, setPlantas] = useState<Planta[]>([]);

    useEffect(() => {
        fetch('http://localhost:5022/api/tipos/listar')
            .then(response => response.json())
            .then(data => setPlantas(data))
            .catch(error => console.error('Erro ao listar plantas:', error));
    }, []);

    return (
        <div>
            <h2>Lista de Plantas</h2>
            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Nome</th>
                        <th>Origem</th>
                        <th>Tipo</th>
                        <th>Criado Em</th>
                    </tr>
                </thead>
                <tbody>
                    {plantas.map(planta => (
                        <tr key={planta.idPlanta}>
                            <td>{planta.idPlanta}</td>
                            <td>{planta.nome}</td>
                            <td>{planta.origem?.pais || 'N/A'}</td>
                            <td>{planta.tipo?.nome || 'N/A'}</td>
                            <td>{new Date(planta.criadoEm).toLocaleDateString()}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default ListaPlantas;
