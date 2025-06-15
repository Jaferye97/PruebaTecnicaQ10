const inputBuscarEstudiante = document.getElementById('buscarInput');
const selectEstudiante = document.getElementById('estudianteSelect');
const btnBuscarHistorial = document.getElementById('btnBuscarHistorial');
const tabla = document.getElementById('tablaHistorial');
const tbody = tabla.querySelector('tbody');


inputBuscarEstudiante.addEventListener('keyup', function () {
    const filtro = this.value;
    if (filtro.length < 5) return;

    fetch(`/AsignacionMateriaEstudiante/BuscarEstudiantes?filtro=${encodeURIComponent(filtro)}`)
        .then(res => res.json())
        .then(data => {
            selectEstudiante.innerHTML = '<option value="">-- Seleccione un estudiante --</option>';
            data.forEach(est => {
                const option = document.createElement('option');
                option.value = est.id;
                option.text = `${est.nombre} - ${est.documento}`;
                selectEstudiante.appendChild(option);
            });
        });
});

btnBuscarHistorial.addEventListener('click', function () {
    const id = selectEstudiante.value;
    if (!id) return alert("Seleccione un estudiante");

    fetch(`/AsignacionMateriaEstudiante/BuscarHistorial?estudianteId=${id}`)
        .then(res => res.json())
        .then(data => {
            tbody.innerHTML = '';
            data.forEach(m => {
                const tr = document.createElement('tr');
                tr.innerHTML = `
							<td>${m.codigoMateria} ${m.nombreMateria}</td>
							<td>${m.creditosMateria}</td>
							<td>${m.mesSemestre}</td>
							<td>${m.anioSemestre}</td>`;
                tbody.appendChild(tr);
            });
            tabla.style.display = 'table';
        });
});