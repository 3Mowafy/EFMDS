document.addEventListener('DOMContentLoaded', function () {
    const filterRadios = document.querySelectorAll('.filter-radio');
    const doctorsListContainer = document.getElementById('doctors-list');

    filterRadios.forEach(radio => {
        radio.addEventListener('change', function () {
            // Get selected filters
            const specialty = document.querySelector('input[name="specialty"]:checked')?.value || '';
            const title = document.querySelector('input[name="title"]:checked')?.value || '';

            // Optional: Show loading state
            doctorsListContainer.style.opacity = '0.5';

            // Fetch filtered data
            const url = `/Home/FilterDoctors?specialty=${encodeURIComponent(specialty)}&title=${encodeURIComponent(title)}`;
            
            fetch(url)
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    return response.text();
                })
                .then(html => {
                    doctorsListContainer.innerHTML = html;
                    doctorsListContainer.style.opacity = '1';
                })
                .catch(error => {
                    console.error('Error fetching filtered doctors:', error);
                    doctorsListContainer.style.opacity = '1';
                });
        });
    });
});
