function previewAvatar(input) {
    const preview = document.getElementById('avatarPreview');
    if (!preview || !input.files || !input.files[0]) return;
    const file = input.files[0];
    if (file.size > 2 * 1024 * 1024) {
        alert('Ảnh không được vượt quá 2MB.');
        input.value = '';
        return;
    }
    preview.src = URL.createObjectURL(file);
    preview.style.display = 'block';
}
