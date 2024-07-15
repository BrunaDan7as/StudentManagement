import React, { useState } from 'react';
import { Modal, Button, OverlayTrigger, Tooltip } from 'react-bootstrap';


interface ConfirmationModalProps {
    onConfirm: () => void;
    onCancel: () => void;
}

const ConfirmationModal: React.FC<ConfirmationModalProps> = ({ onConfirm, onCancel }) => {
    return (
        <Modal.Body>
            <div className="d-flex justify-content-around">
                <Button variant="success" onClick={onConfirm}>Confirmar</Button>
                <Button variant="danger" onClick={onCancel}>Cancelar</Button>
            </div>
        </Modal.Body>
    );
};

interface MyComponentProps {
    onConfirmationAction: () => void;
}

const DeleteButtonConfirm: React.FC<MyComponentProps> = ({ onConfirmationAction }) => {
    const [isModalOpen, setIsModalOpen] = useState(false);

    const handleOpenModal = () => {
        setIsModalOpen(true);
    };

    const handleCloseModal = () => {
        setIsModalOpen(false);
    };

    const handleConfirm = () => {
        handleCloseModal();
        onConfirmationAction();
    };

    const handleCancel = () => {
        handleCloseModal();
    };

    return (
        <div>
            <Button variant="danger" size="sm" onClick={handleOpenModal}>
          Excluir
        </Button>

            <Modal
                size="sm"
                centered={true}
                show={isModalOpen}
                onHide={handleCloseModal}>
                <Modal.Header closeButton  >
                    Tem certeza que deseja excluir ?
                </Modal.Header>
                <ConfirmationModal onConfirm={handleConfirm} onCancel={handleCancel} />
            </Modal>
        </div>
    );
};

export default DeleteButtonConfirm;