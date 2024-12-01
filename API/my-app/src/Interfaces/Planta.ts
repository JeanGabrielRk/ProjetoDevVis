
export interface Planta {
    idPlanta: number;
    nome: string;
    origemId: number;
    tipoId: number;
    criadoEm: string;
    origem?: {
        idOrigem: number;
        pais: string;
    };
    tipo?: {
        tipoId: number;
        nome: string;
    };
}