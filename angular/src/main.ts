import { enableProdMode } from '@angular/core';
import { bootstrapApplication } from '@angular/platform-browser';

import { AppComponent } from './app/app.component';
import { appConfig } from './app/app.config';
import { environment } from './environments/environment';

if (environment.production) {
  enableProdMode();
}

// bootstrapApplication(AppComponent, appConfig).catch(err => console.error(err));

// Tạo giao diện đơn giản để hiển thị environment
function createEnvironmentDisplay() {
  // Tạo container chính
  const container = document.createElement('div');
  container.style.fontFamily = 'Arial, sans-serif';
  container.style.padding = '20px';
  container.style.maxWidth = '800px';
  container.style.margin = '0 auto';
  
  const rawJson = document.createElement('pre');
  rawJson.textContent = JSON.stringify(environment, null, 2);
  rawJson.style.backgroundColor = '#2c3e50';
  rawJson.style.color = '#ecf0f1';
  rawJson.style.padding = '15px';
  rawJson.style.borderRadius = '5px';
  rawJson.style.overflow = 'auto';
  rawJson.style.fontSize = '12px';
  rawJson.style.lineHeight = '1.4';
  
  // Thêm tất cả vào container
  container.appendChild(rawJson);
  return container;
}
// Hiển thị khi DOM đã sẵn sàng
document.addEventListener('DOMContentLoaded', () => {
  document.body.appendChild(createEnvironmentDisplay());
});