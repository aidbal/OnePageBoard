export class Constants {
  readonly backendUrl = 'http://localhost:63143';
  readonly webApiUrl = `${this.backendUrl}/api`;
  readonly postsApiUrl = `${this.webApiUrl}/posts`;
  readonly commentsApiUrl = `${this.webApiUrl}/comments`;
}
